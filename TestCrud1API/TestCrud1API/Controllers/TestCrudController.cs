using Microsoft.AspNetCore.Mvc;

namespace TestCrud1API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestCrudController : ControllerBase
    {
        private static List<TestCrud> employees = new List<TestCrud>
            {
                new TestCrud {
                Id = 1,
                Name =  "Audie",
                Role = "Managing Director",
                Email = "audie@intidatautama.com"
                },
                new TestCrud {
                Id = 2,
                Name =  "Moro",
                Role = "Head Bussiness Operation",
                Email = "moro@intidatautama.com"
                }
            };
        [HttpGet]
        public async Task<ActionResult<List<TestCrud>>> Get()
        {
            
            return Ok(employees);
        }

        [HttpPost]

        public async Task<ActionResult<List<TestCrud>>> AddEmployee(TestCrud employee)
        {
            employees.Add(employee);
            return Ok(employees);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TestCrud>>> Delete(int id)
        {
            var employee = employees.Find(h => h.Id == id);
            if (employee == null)
                return BadRequest("Database not found.");

            employees.Remove(employee);
            return Ok(employees);
        }
        [HttpPut]

        public async Task<ActionResult<List<TestCrud>>> UpdateEmployee(TestCrud request)
        {
            var employee = employees.Find(h => h.Id == request.Id);
            if (employee == null)
                return BadRequest("Database not found.");

            employee.Name = request.Name;
            employee.Role = request.Role;
            employee.Email = request.Email;

            return Ok(employees);
        }
    }
}
