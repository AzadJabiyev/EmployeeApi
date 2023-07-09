using EmployeeApi.Models;
using EmployeeApi.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeControllerService _service;

        public EmployeeController(IEmployeeControllerService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task Create(EmployeeModel model) =>
            await _service.CreateAsync(model);

        [HttpGet]
        public async Task<List<EmployeeModel>> GetAll() =>
             await _service.GetAllAsync();
    }
}