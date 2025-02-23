using EmployeeLeaveManagementSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagementSystem.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveApprovalController : Controller
    {
        ApplicationDbContext _context;
        public LeaveApprovalController(ApplicationDbContext context) {
            _context = context;

        }
        [HttpGet]
        public IActionResult GetLeaveDetails(ApprovalForm approvalForm)
        {

            var Approvalform = (from a in _context.LeaveRequests
                                where a.Status == "Submitted"
                                select new ApprovalForm
                                {
                                    //EmployeeID = a.EmployeeId,
                                    StartDate = a.StartDate,
                                    EndDate = a.EndDate,
                                    Status = a.Status
                                }).ToList();
            return Ok(approvalForm);
        }
        [HttpPost]
        public IActionResult ApproveLeaveRequest( LeaveRequest leaveRequest)
        {
            if (leaveRequest.Status == "Approved")
            {
                _context.LeaveRequests.Update(leaveRequest);
                var employee = _context.Employees.FirstOrDefault(e => e.Id == leaveRequest.UserId);
                if (employee == null)
                {
                    return NotFound();
                }

                // Check if the employee has enough leave days
                if (employee.LeaveBalance < leaveRequest.NoOfLeaves)
                {
                    return BadRequest("Insufficient leave balance.");
                }

                // Approve the leave request and update the employee's leave count
                // leaveRequest.IsApproved = true;
                leaveRequest.Status = leaveRequest.Status;
                employee.LeaveBalance -= leaveRequest.NoOfLeaves;
                _context.SaveChanges();
                return Ok(leaveRequest);
            }
            else
            {
                _context.LeaveRequests.Update(leaveRequest);
                _context.SaveChanges();
                return Ok(leaveRequest);
            }
        }
     
    }
}
