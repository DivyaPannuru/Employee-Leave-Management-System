using EmployeeLeaveManagementSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeLeaveManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public RegistrationController(ApplicationDbContext context)
        {
            _context = context;
                
        }
        // POST api/<RegistrationController>
        [Authorize(Roles="Admin")]
        [HttpPost]
        public void Post([FromBody] Register register)
        {
            var newuser = register.User;
            var newEmployee =register.Employee;
            _context.Employees.Add(newEmployee);
            _context.Users.Add(newuser);
            _context.SaveChanges();

        }

        // PUT api/<RegistrationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Register register)
        {
        }

        // DELETE api/<RegistrationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
