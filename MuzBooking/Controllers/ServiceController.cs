using Microsoft.AspNetCore.Mvc;
using MuzBooking.Entities;
using System.Linq;

namespace MuzBooking.Controllers
{
    [ApiController]
    [Route("api/[controller]/booking")]
    public class ServiceController : ControllerBase
    {
        private readonly ILogger<ServiceController> _logger;
        private readonly AppDbContext _DbContext;

        public ServiceController(ILogger<ServiceController> logger,AppDbContext dbContext)
        {
            _logger = logger;
            _DbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<ServiceObject> Get()
        {
            var k = _DbContext.ServicesObjects.ToList();
            _DbContext.SaveChanges();
            return k;
        }
       
    }
}