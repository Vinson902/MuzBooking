using Microsoft.AspNetCore.Mvc;
using MuzBooking.DataAccess;
using MuzBooking.Entities;
using System.Linq;

namespace MuzBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;
        private readonly IServiceObjectRepository _serviceObject;
        private readonly IEquipmentRepository _equipmentRepository;

        public ServiceController(ILogger<ServiceController> logger, IServiceObjectRepository serviceObject, IEquipmentRepository equipmentRepository)
        {
            _logger = logger;
            _serviceObject = serviceObject;
            _equipmentRepository = equipmentRepository;
        }

        [HttpGet]
        public IEnumerable<ServiceObject> Get()
        {
            return _serviceObject.GetAll();
        }
        [HttpPost("create")]
        public ActionResult Create(string name, int amount)
        {
            return CreatedAtAction(nameof(Create), _equipmentRepository.CreateEquipment(name, amount));
        }
        [HttpPost("Update/{id}")]
        public ActionResult Update(Guid id, string? name, int? amount)
        {
            try { _equipmentRepository.GetByGuid(id); }
            catch (Exception)
            {
                return NotFound($"Equipment with id - {id} doesn't exist");
            }
            return Ok(_equipmentRepository.UpdateEquipment(id, name, amount));
        }
        [HttpPost("booking")]
        public ActionResult CreateOrder(Guid id, int amount)
        {
            var equipment = _equipmentRepository.GetByGuid(id);
            if (amount <= equipment.AvailableAmount)
            {
                _serviceObject.CreateBooking(id, equipment.Name, amount, equipment.Id);
                _equipmentRepository.UpdateEquipment(id, amount: equipment.AvailableAmount - amount);
                return Ok(new RequestResult
                {
                    Ok = true,
                    Amount = equipment.AvailableAmount,
                });
            }
            return BadRequest(new RequestResult
            {
                Ok = false,
                Amount = 0,
                Error = $"Guess what :) we don't have enough {equipment.Name} at the moment"
            });
        }
    }
}
