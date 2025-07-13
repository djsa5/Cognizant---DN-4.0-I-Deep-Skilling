using JwtAuthApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,POC")] // Only users with Admin or POC role
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> empList = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice" },
            new Employee { Id = 2, Name = "Bob" }
        };

        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            return Ok(empList);
        }

        [HttpPost]
        public ActionResult<Employee> Add(Employee emp)
        {
            emp.Id = empList.Max(e => e.Id) + 1;
            empList.Add(emp);
            return Ok(emp);
        }
    }
}
