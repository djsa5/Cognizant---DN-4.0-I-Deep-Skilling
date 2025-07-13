using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using EmployeeApiWithFilters.Filters;
using EmployeeApiWithFilters.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApiWithFilters.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthFilter]
    [ServiceFilter(typeof(CustomExceptionFilter))]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Alice",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "Communication" },
                        new Skill { Id = 2, Name = "Recruitment" }
                    },
                    DateOfBirth = new DateTime(1990, 5, 23)
                }
            };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<Employee>> Get()
        {
            throw new Exception("This is a test exception."); // to test exception filter
            return GetStandardEmployeeList();
        }

        [HttpGet("standard")]
        public ActionResult<Employee> GetStandard()
        {
            return GetStandardEmployeeList().FirstOrDefault();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee emp)
        {
            return Ok("Employee added");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee emp)
        {
            return Ok($"Employee {id} updated");
        }
    }
}
