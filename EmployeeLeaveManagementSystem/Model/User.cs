namespace EmployeeLeaveManagementSystem.Model
{
    public class User
    {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Role  { get; set; }
        public string Password { get; set; }// Note: Use a secure method to store passwords in production

    }
    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
