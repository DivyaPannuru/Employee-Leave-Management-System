using EmployeeLeaveManagementSystem.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagementSystem.Controllers
{
<<<<<<< HEAD
   // [Authorize(Roles ="Admin")]
=======
    // [Authorize(Roles ="Admin")]
>>>>>>> Feature_Sravya
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
<<<<<<< HEAD
                                join b in _context.Employees on a.EmployeeId equals b.Id
                                where a.Status == "Pending".ToLower()
                                select new ApprovalForm
                                {
                                    EmployeeName = b.FirstName +" " + b.LastName,
                                    StartDate = a.StartDate,
                                    EndDate = a.EndDate,
                                    Status = a.Status,id=a.Id,
=======
                                join b in _context.Users on a.UserId equals b.Id
                                where a.Status == "Pending".ToLower()
                                select new ApprovalForm
                                {
                                    UserName = b.Username,
                                    StartDate = a.StartDate,
                                    EndDate = a.EndDate,
                                    Status = a.Status,
                                    id = a.Id,
>>>>>>> Feature_Sravya
                                    Quantity = a.NoOfLeaves
                                }).ToList();
            return Ok(Approvalform);
        }
        [HttpPost]
        public IActionResult ApproveLeaveRequest(ApprovalForm leaveRequest)
        {
            if (leaveRequest.Status == "Approved".ToLower())
<<<<<<< HEAD
            { 
                var getleaverequest = _context.LeaveRequests.Where(x => x.Id == leaveRequest.id).Select(x => new LeaveRequest
            {
                Id = x.Id,
                StartDate= x.StartDate,
                EmployeeId = x.EmployeeId,
                EndDate= x.EndDate,
                Status = leaveRequest.Status,
                NoOfLeaves = x.NoOfLeaves,
                Leavetypeid = x.Leavetypeid,
                Reason = x.Reason
            }).FirstOrDefault();
                
                _context.LeaveRequests.Update(getleaverequest);
                var employee = _context.Employees.FirstOrDefault(e => e.Id == getleaverequest.EmployeeId);
                if (employee == null)
=======
            {
                var getleaverequest = _context.LeaveRequests.Where(x => x.Id == leaveRequest.id).Select(x => new LeaveRequest
>>>>>>> Feature_Sravya
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
                    UserId = x.UserId,
                    EndDate = x.EndDate,
                    Status = leaveRequest.Status,
                    NoOfLeaves = x.NoOfLeaves,
                    LeaveType = x.LeaveType,
                    Reason = x.Reason
                }).FirstOrDefault();

<<<<<<< HEAD
                // Check if the employee has enough leave days
                if (employee.LeaveBalance < leaveRequest.Quantity)
                {
                    return BadRequest("Insufficient leave balance.");
                }

                // Approve the leave request and update the employee's leave count
                // leaveRequest.IsApproved = true;
               // leaveRequest.Status = leaveRequest.Status;
                employee.LeaveBalance -= leaveRequest.Quantity;
=======
                _context.LeaveRequests.Update(getleaverequest);
              
>>>>>>> Feature_Sravya
                _context.SaveChanges();
                return Ok(getleaverequest);
            }
            else
            {
                //leaveRequest.Reason = "Default Reson";
                //_context.LeaveRequests.Update(q);
                var getleaverequest = _context.LeaveRequests.Where(x => x.Id == leaveRequest.id).Select(x => new LeaveRequest
                {
                    Id = x.Id,
                    StartDate = x.StartDate,
<<<<<<< HEAD
                    EmployeeId = x.EmployeeId,
                    EndDate = x.EndDate,
                    Status = leaveRequest.Status,
                    NoOfLeaves = x.NoOfLeaves,
                    Leavetypeid = x.Leavetypeid,
                    Reason = x.Reason
                }).FirstOrDefault();
                _context.LeaveRequests.Update(getleaverequest);
=======
                    UserId = x.UserId,
                    EndDate = x.EndDate,
                    Status = leaveRequest.Status,
                    NoOfLeaves = x.NoOfLeaves,
                    LeaveType = x.LeaveType,
                    Reason = x.Reason
                }).FirstOrDefault();
                _context.LeaveRequests.Update(getleaverequest);

                var updateUserleavebalance = _context.Users.Where(x => x.Id == getleaverequest.UserId).FirstOrDefault();
                if (updateUserleavebalance != null)
                {
                    if(getleaverequest.LeaveType.ToLower() == "sick")
                    {
                        updateUserleavebalance.PendingSickLeaves += getleaverequest.NoOfLeaves;
                    }
                    else if (getleaverequest.LeaveType.ToLower() == "vacation")
                    {
                        updateUserleavebalance.PendingVacationLeaves += getleaverequest.NoOfLeaves;
                    }
                    else 
                    {
                        updateUserleavebalance.PendingOtherLeaves += getleaverequest.NoOfLeaves;
                    }
                }

>>>>>>> Feature_Sravya
                _context.SaveChanges();
                return Ok(leaveRequest);
            }
        }

    }
}
