using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class TaskDbContext : DbContext
    {
         public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }
        public DbSet<Data.Model.Task> Tasks { get; set; }
        public DbSet<Data.Model.TaskUpdate> TaskUpdates { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // Replace 'YourConnectionString' with the actual connection string to your Azure SQL database
        //    optionsBuilder.UseSqlServer("Server=tcp:ura19923.database.windows.net,1433;Initial Catalog=task;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=\"Active Directory Default\";");
        //}
    }
}
