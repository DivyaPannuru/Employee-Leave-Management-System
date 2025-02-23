namespace EmployeeLeaveManagementSystem.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Note: Use a secure method to store passwords in production
        public string? UserRole { get; set; }
        public int PendingSickLeaves { get; set; }
        public int PendingVacationLeaves { get; set; }
        public int PendingOtherLeaves { get; set; }



        //public int EmployeeId { get; set; }
        //public Employee Employee { get; internal set; }
    }
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
