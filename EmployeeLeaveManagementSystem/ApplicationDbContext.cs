using EmployeeLeaveManagementSystem.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLeaveManagementSystem
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOne(u => u.User)
                .WithOne(static e => e.Employee)
                .HasForeignKey<User>(e => e.EmployeeId);

            modelBuilder.Entity<Employee>()
            .HasMany(e => e.LeaveRequest)
            .WithOne(lr => lr.Employee)
            .HasForeignKey(lr => lr.EmployeeId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
