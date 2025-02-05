using EmployeeLeaveManagementSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeaveManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveRequestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeaveRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetLeaveRequests()
        {
            var leaveRequests = _context.LeaveRequests.ToList();
            return Ok(leaveRequests);
        }

        [HttpPost]
        public IActionResult CreateLeaveRequest([FromBody] LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Add(leaveRequest);
            _context.SaveChanges();
            return Ok(leaveRequest);
        }
    }

}
