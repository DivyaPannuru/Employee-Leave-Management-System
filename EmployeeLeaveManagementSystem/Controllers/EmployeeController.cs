using EmployeeLeaveManagementSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok(employee);
        }
    }

}
