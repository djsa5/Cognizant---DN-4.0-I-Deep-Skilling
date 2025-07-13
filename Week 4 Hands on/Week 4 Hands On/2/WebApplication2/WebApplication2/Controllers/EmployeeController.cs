using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Models;
using System.Collections.Generic;

namespace MyFirstWebAPI.Controllers
{
    [ApiController]
    [Route("api/emp")]  // Custom route
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Alice", Department = "HR" },
                new Employee { Id = 2, Name = "Bob", Department = "IT" }
            };
            return Ok(employees);
        }
    }
}

