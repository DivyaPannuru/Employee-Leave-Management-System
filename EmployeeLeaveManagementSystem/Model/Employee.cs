﻿namespace EmployeeLeaveManagementSystem.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OfficeAddress { get; set; }
        public int LeaveBalance { get; set; }
        public User? User { get; internal set; }
        public ICollection<LeaveRequest> LeaveRequest { get; set; }
    }
    public class Register
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public User User { get; set; }
    }
}
