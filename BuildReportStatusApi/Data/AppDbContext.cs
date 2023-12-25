using BuildReportStatusApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BuildReportStatusApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TaskHeader> TaskHeaders { get; set; }
    }
}
