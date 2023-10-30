using AutoMapper;
using EmployeesTest.Data.Db;
using EmployeesTest.Data.Db.Enteties;
using EmployeesTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesTest.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeesController(EmployeeRepository repository, IMapper mapper) 
        { 
            _repository = repository;
            _mapper = mapper;
        }

        [Route("")]
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<ActionResult> List()
        {
            var employees = await _repository.GetAllEmployees();

            var employeeViews = _mapper.Map <EmployeeView[]>(employees);

            return View(employeeViews);
        }
    }
}
