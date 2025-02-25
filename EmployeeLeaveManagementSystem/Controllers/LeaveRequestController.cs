using EmployeeLeaveManagementSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet("id")]
        public IActionResult GetAppliedLeaveDetails(int id)
        {
            var leavedetails = from a in _context.Users
                               join b in _context.LeaveRequests
                               on a.Id equals b.UserId
                               where b.UserId == id

                               select new
                               {
                                   startDate = b.StartDate,
                                   endDate = b.EndDate,
                                   type = b.Reason,
                                   status = b.Status,
                               };
            return Ok(leavedetails);
        }

        [HttpPost]
        public IActionResult CreateLeaveRequest([FromBody] LeaveForm leaveRequest)
        {
            var leaveRequests = new LeaveRequest();
            leaveRequests.UserId = leaveRequest.Id;
            leaveRequests.StartDate = leaveRequest.StartDate;
            leaveRequests.EndDate = leaveRequest.endDate;
            leaveRequests.NoOfLeaves = leaveRequest.Quanity;
            leaveRequests.Reason = leaveRequest.Reason;
            leaveRequests.Status = "Pending"; //Approve /Reject
            var userbalance = _context.Users.Where(a => a.Id == leaveRequests.UserId).FirstOrDefault();
            if (leaveRequest.Reason.ToLower() == "Sick".ToLower())
            {

                if (userbalance.PendingSickLeaves >= leaveRequest.Quanity)
                {
                    _context.Users
   .Where(t => t.Id == leaveRequest.Id)
   .ExecuteUpdate(b => b.SetProperty(x => x.PendingSickLeaves, x => x.PendingSickLeaves - leaveRequest.Quanity));
                }
                else
                {
                    return BadRequest("insuciffent balance");
                }
            }
            else if (leaveRequest.Reason.ToLower() == "Vacation".ToLower())
            {
                if (userbalance.PendingVacationLeaves >= leaveRequest.Quanity)
                {
                    _context.Users
   .Where(t => t.Id == leaveRequest.Id)
   .ExecuteUpdate(b => b.SetProperty(x => x.PendingVacationLeaves, x => x.PendingVacationLeaves - leaveRequest.Quanity));
                }
                else
                {
                    return BadRequest("insuciffent balance");
                }
            }
            else
            {
                if (userbalance.PendingOtherLeaves >= leaveRequest.Quanity)
                {
                    _context.Users
   .Where(t => t.Id == leaveRequest.Id)
   .ExecuteUpdate(b => b.SetProperty(x => x.PendingOtherLeaves, x => x.PendingOtherLeaves - leaveRequest.Quanity));
                }
                else
                {
                    return BadRequest("insuciffent balance");
                }
            }
            _context.LeaveRequests.Add(leaveRequests);
            _context.SaveChanges();
            return Ok(leaveRequest);
        }

    }

}