using Microsoft.EntityFrameworkCore;
using TaskManagement1.Controllers;
using TaskManagement1.Models;

namespace TaskManagement1.Data
{
    public class TaskContextData : DbContext
    {
        public TaskContextData(DbContextOptions<TaskContextData> op) : base(op)
        {

        }
        public DbSet<TaskInfoModel> Tasks { get; set; }
        public DbSet<AssignTaskModel> AssignTasks { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }
        public DbSet<EmployeeModel> Employees { get; set; }

        public static implicit operator TaskContextData(AssignTaskController v)
        {
            throw new NotImplementedException();
        }
    }
}
