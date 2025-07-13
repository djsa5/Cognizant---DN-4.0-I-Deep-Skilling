using EmployeeCrudApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeCrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Department = "HR", Salary = 50000 },
            new Employee { Id = 2, Name = "Bob", Department = "IT", Salary = 60000 },
            new Employee { Id = 3, Name = "Charlie", Department = "Finance", Salary = 70000 }
        };

        // GET all
        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            return Ok(employees);
        }

        // GET by id
        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound("Employee not found");
            return Ok(emp);
        }

        // PUT - update
        [HttpPut("{id}")]
        public ActionResult<Employee> Update(int id, [FromBody] Employee updatedEmp)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return BadRequest("Invalid employee id");

            // Update fields
            emp.Name = updatedEmp.Name;
            emp.Department = updatedEmp.Department;
            emp.Salary = updatedEmp.Salary;

            return Ok(emp);
        }

        // POST - create
        [HttpPost]
        public ActionResult<Employee> Create(Employee emp)
        {
            emp.Id = employees.Max(e => e.Id) + 1;
            employees.Add(emp);
            return CreatedAtAction(nameof(GetById), new { id = emp.Id }, emp);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp == null)
                return NotFound("Employee not found");
            employees.Remove(emp);
            return NoContent();
        }
    }
}
