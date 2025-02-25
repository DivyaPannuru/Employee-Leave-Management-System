namespace EmployeeLeaveManagementSystem.Model
{
    public class User
    {
<<<<<<< HEAD
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; } // Note: Use a secure method to store passwords in production
            public string? UserRole { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; internal set; }
=======
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // Note: Use a secure method to store passwords in production
        public string? UserRole { get; set; }
        public int PendingSickLeaves { get; set; }
        public int PendingVacationLeaves { get; set; }
        public int PendingOtherLeaves { get; set; }



        //public int EmployeeId { get; set; }
        //public Employee Employee { get; internal set; }
>>>>>>> Feature_Sravya
    }
    public class LoginUser
    {
        public string Username { get; set; }
        public List<String> Roles { get; set; }
        public string Password { get; set; }
    }
<<<<<<< HEAD


=======
    public class LoginUser
    {
        public string Username { get; set; }
        public List<String> Roles { get; set; }
        public string Password { get; set; }
    }
>>>>>>> Feature_Sravya
}
