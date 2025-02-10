namespace EmployeeLeaveManagementSystem.Model
{
    public class User
    {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; } // Note: Use a secure method to store passwords in production
            public string UserRole { get; set; }
         

    }
    public class LoginUser
    {
        public string Username { get; set; }
        public List<String> Roles { get; set; }
    }


}
