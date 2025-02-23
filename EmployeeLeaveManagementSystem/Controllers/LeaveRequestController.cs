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
        public IActionResult CreateLeaveRequest([FromBody] LeaveForm leaveRequest)
        {
            var leaveRequests = new LeaveRequest();
            //leaveRequests.EmployeeId = leaveRequest.EmployeeId;
            leaveRequests.StartDate= leaveRequest.StartDate;
            leaveRequests.EndDate = leaveRequest.endDate;
            leaveRequests.NoOfLeaves = leaveRequest.Quanity;
            leaveRequests.Reason = leaveRequest.Reason;
            leaveRequests.Status = "Submitted"; //Approve /Reject
            _context.LeaveRequests.Add(leaveRequests);
            _context.SaveChanges();
            return Ok(leaveRequest);
        }
       
    }

}
