using Microsoft.AspNetCore.Mvc;
using WebApplication4.models;
using WebApplication4.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get() =>
            _employeeService.Get();

        [HttpGet]
        [Route("{id:length(24)}")]
        [ActionName("GetEmployee")]

        public ActionResult<Employee> GetEmployee(string id)
        {
            var emp = _employeeService.Get(id);

            if (emp == null)
            {
                return NotFound();
            }

            return emp;
        }

        [HttpPut]

        public ActionResult<Employee> UpdateEmployee(string id, [FromBody] AddEmp empIn)
        {
            var emp= _employeeService.Get(id);
            if(emp==null) { 
                return NotFound();
            }
            emp.Name= empIn.Name;
            emp.Email= empIn.Email;
            emp.phone = empIn.phone;
            emp.Address=empIn.Address;

            _employeeService.Update(id, emp);

            return Ok(emp);
        }

        [HttpDelete] 
        public ActionResult<object> DeleteEmployee(string id)
        {
            var emp = _employeeService.Get(id);

            _employeeService.Delete(id);
            return new { Id = id, Message = "Employee with ID " + id + " has been deleted." };
        }
    

            [HttpPost]
        public ActionResult<Employee> Create(AddEmp emp)
        {

            var emps = new AddEmp()
            {
                Name = emp.Name,
                Address = emp.Address,
                phone = emp.phone,
                Email = emp.Email,
            };
            var employee = new Employee()
            {
                Name = emps.Name,
                Address = emps.Address,
                phone = emps.phone,
                Email = emps.Email,
            };
          var emp1=  _employeeService.Create(employee);

            // return CreatedAtRoute(nameof(GetEmployee), new { id = emp.Id }, emp);
            return emp1;
        }



    }
}
