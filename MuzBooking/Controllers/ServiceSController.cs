using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MuzBooking.Entities;

namespace MuzBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceSController : ControllerBase
    {
        private readonly AppDbContext _DbContext;
        private readonly ILogger<ServiceSController> _Logger;

        public ServiceSController(AppDbContext dbContext, ILogger<ServiceSController> logger)
        {
            _DbContext = dbContext;
            _Logger = logger;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_DbContext.ServicesObjects.ToList());
        }

        [HttpPost("create")]
        public ActionResult Create(string name, int amount)
        {
            var id = Guid.NewGuid();
            _DbContext.EquipmentObjects.Add(new Equipment
            {
                CreatedAt = DateTime.Now,
                Name = name,
                Amount = amount,
                EquipmentGuid = id,
            });
            _DbContext.SaveChanges();
            return CreatedAtAction(nameof(Create), id);
        }
        [HttpPost("Update/{id}")]
        public ActionResult Update(Guid id, string? name, int? amount)
        {
            if (_DbContext.EquipmentObjects.Any(x => x.EquipmentGuid == id))
            {
                var equipment = _DbContext.EquipmentObjects.First(x => x.EquipmentGuid == id);
                if (!(amount is null))
                    equipment.Amount = amount.Value;
                if (!(name is null))
                    equipment.Name = name;
                _DbContext.SaveChanges();
                return Ok(equipment.EquipmentGuid);
            }
            return NotFound($"{id} is not found");
        }
        [HttpPost("booking")]
        public ActionResult CreateOrder(Guid id, int amount)
        {
            if (_DbContext.EquipmentObjects.Any(x => x.EquipmentGuid == id && x.Amount >= amount))
            {
                var equipment = _DbContext.EquipmentObjects.First(x => x.EquipmentGuid == id);
                _DbContext.Attach(equipment);
                _DbContext.ServicesObjects.Add(new ServiceObject
                {
                    CreatedAt = DateTime.Now,
                    EquipmentGuid = id,
                    Amount = amount,
                    Name = equipment.Name,
                    EquipmentId = equipment.Id
                });
                equipment.Amount -= amount;
                _DbContext.EquipmentObjects.Update(equipment);
                _DbContext.SaveChanges();
                return CreatedAtAction(nameof(CreateOrder), new RequestResult
                {
                    Ok = true,
                    Amount = equipment.Amount,
                });
            }
            return BadRequest(new RequestResult
            {
                Ok = false,
                Amount = 0,
                Error = $"It appears that we don't have enough {id} at the moment"
            });
        }
    }
}
