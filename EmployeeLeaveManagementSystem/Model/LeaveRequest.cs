using System.ComponentModel.DataAnnotations;

namespace EmployeeLeaveManagementSystem.Model
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Reason { get; set; }
        public string Status { get; set; }
        public int NoOfLeaves {  get; set; }    
        public int Leavetypeid { get; set; }
        public Employee Employee { get; set; }

    }
    public class LeaveForm
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime endDate { get; set; }
        public string Reason { get; set; }
        = string.Empty;
        public int Quanity { get; set; } //should be auto fill 

    }
    public class ApprovalForm
    {
        public int id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeID { get; set; }
        public required string Status { get; set; } 
    }
    public class LeaveType
    {
        public int id { get; set; }
        public required string LeaveTypeName
        {
            get; set;
        }
    }
}