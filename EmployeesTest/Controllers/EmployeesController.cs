using AutoMapper;
using EmployeesTest.Data.Db;
using EmployeesTest.Data.Db.Enteties;
using EmployeesTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.Diagnostics.CodeAnalysis;

namespace EmployeesTest.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly EmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(EmployeeRepository repository, IMapper mapper) 
        { 
            _employeeRepository = repository;
            _mapper = mapper;
        }

        [Route("")]
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<ActionResult> List()
        {
            var employees = await _employeeRepository.GetAllAsync();

            var employeeViews = _mapper.Map <EmployeeView[]>(employees);

            return View(employeeViews);
        }
        
        public async Task<ActionResult> Delete([FromRoute]int id)
        {
            var employee = await _employeeRepository.FindAsync(id);

            if (employee is null)
                return NotFound();

            _employeeRepository.Delete(employee);

            await _employeeRepository.SaveChangesAsync();

            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<ActionResult> Edit([FromRoute] int id)
        {
            var employee = await _employeeRepository.FindAsync(id);

            var editEmployeeView = _mapper.Map<EditEmployeeView>(employee);

            var departments = await _employeeRepository.GetAllDepartmentsAsync();

            var positions = await _employeeRepository.GetAllPositionsAcync();

            editEmployeeView.Positions = positions;
            editEmployeeView.Departments= departments;

            return View(editEmployeeView);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Employee employee)
        {
                _employeeRepository.UpdateEmplyee(employee);

            await _employeeRepository.SaveChangesAsync();

            return RedirectToAction("List");
        }


    }
}
