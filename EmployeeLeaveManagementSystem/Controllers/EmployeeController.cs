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
       [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }
        [Authorize(Roles = "User")]
        [HttpGet("id")]
        public IActionResult GetEmployee(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);
            return Ok(employee);
        }
        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        //public IActionResult CreateEmployee([FromBody] Employee employee)
        //{
        //    _context.Employees.Add(employee);
        //    _context.SaveChanges();
        //    return Ok(employee);
        //}
    }

}
