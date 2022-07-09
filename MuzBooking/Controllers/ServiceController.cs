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
        public Guid Create(string name, int amount)
        {
            return _equipmentRepository.CreateEquipment(name, amount);
        }
        [HttpPost("Update/{id}")]
        public Guid Update(Guid id, string? name, int? amount)
        {
            return _equipmentRepository.UpdateEquipment(id, name, amount);
        }
        [HttpPost("booking")]
        public RequestResult CreateOrder(Guid id, int amount)
        {
            var equipment = _equipmentRepository.GetByGuid(id);
            if (amount <= equipment.Amount)
            {
                _serviceObject.CreateBooking(id, equipment.Name, amount, equipment.Id);
                _equipmentRepository.UpdateEquipment(id, amount: equipment.Amount - amount);
                return new RequestResult
                {
                    Ok = true,
                    Amount = equipment.Amount,
                };
            }
            return new RequestResult
            {
                Ok = false,
                Amount = 0,
                Error = $"Guess what :)\n we don't have enough {equipment.Name} at the moment"
            };
        }
    }
}
