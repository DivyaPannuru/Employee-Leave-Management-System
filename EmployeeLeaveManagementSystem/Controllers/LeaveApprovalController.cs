using EmployeeLeaveManagementSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagementSystem.Controllers
{
     [Authorize(Roles ="admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class LeaveApprovalController : Controller
    {
        ApplicationDbContext _context;
        public LeaveApprovalController(ApplicationDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public IActionResult GetLeaveDetails()
        {

            var Approvalform = (from a in _context.LeaveRequests
                                join b in _context.Users on a.UserId equals b.Id
                                where a.Status == "Pending".ToLower()
                                select new ApprovalForm
                                {
                                    UserName = b.Username,
                                    StartDate = a.StartDate,
                                    EndDate = a.EndDate,
                                    Status = a.Status,
                                    id = a.Id,
                                    Quantity = a.NoOfLeaves
                                }).ToList();
            return Ok(Approvalform);
        }
        [HttpPost]
        public IActionResult ApproveLeaveRequest(ApprovalForm leaveRequest)
        {
            if (leaveRequest.Status == "Approved".ToLower())
            {
                var getleaverequest = _context.LeaveRequests.Where(x => x.Id == leaveRequest.id).Select(x => new LeaveRequest
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    UserId = x.UserId,
                    EndDate = x.EndDate,
                    Status = leaveRequest.Status,
                    NoOfLeaves = x.NoOfLeaves,
                    Reason = x.Reason
                }).FirstOrDefault();

                _context.LeaveRequests.Update(getleaverequest);

                _context.SaveChanges();
                return Ok(getleaverequest);
            }
            else
            {
                var getleaverequest = _context.LeaveRequests.Where(x => x.Id == leaveRequest.id).Select(x => new LeaveRequest
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    UserId = x.UserId,
                    EndDate = x.EndDate,
                    Status = leaveRequest.Status,
                    NoOfLeaves = x.NoOfLeaves,
                    Reason = x.Reason
                }).FirstOrDefault();
                _context.LeaveRequests.Update(getleaverequest);

                var updateUserleavebalance = _context.Users.Where(x => x.Id == getleaverequest.UserId).FirstOrDefault();
                if (updateUserleavebalance != null)
                {
                    if (getleaverequest.Reason.ToLower() == "sick")
                    {
                        updateUserleavebalance.PendingSickLeaves += getleaverequest.NoOfLeaves;
                    }
                    else if (getleaverequest.Reason.ToLower() == "vacation")
                    {
                        updateUserleavebalance.PendingVacationLeaves += getleaverequest.NoOfLeaves;
                    }
                    else
                    {
                        updateUserleavebalance.PendingOtherLeaves += getleaverequest.NoOfLeaves;
                    }
                }

                _context.SaveChanges();
                return Ok(leaveRequest);
            }
        }

    }
}