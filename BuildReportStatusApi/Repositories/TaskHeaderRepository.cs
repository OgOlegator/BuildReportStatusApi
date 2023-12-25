using BuildReportStatusApi.Data;
using BuildReportStatusApi.Enums;
using BuildReportStatusApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TaskStatus = BuildReportStatusApi.Enums.TaskStatus;

namespace BuildReportStatusApi.Repositories
{
    public class TaskHeaderRepository : ITaskHeaderRepository
    {
        private readonly IConfiguration _config;

        public TaskHeaderRepository(IConfiguration configuration)
        {
            _config = configuration;
        }

        public TaskHeader Create()
        {
            using (var context = GetContext())
            {
                var taskHeader = new TaskHeader
                {
                    Id = Guid.NewGuid(),
                    LastUpdate = DateTime.Now,
                    Status = TaskStatus.Created,
                };

                context.Add(taskHeader);
                context.SaveChanges();

                return taskHeader;
            }
        }

        public TaskHeader GetById(Guid id)
        {
            using (var context = GetContext())
            {
                var result = context.TaskHeaders.FirstOrDefault(task => task.Id == id);

                if (result == null)
                    throw new KeyNotFoundException();

                return result;
            }
        }

        public void Update(Guid id, TaskStatus status)
        {
            var updateTask = GetById(id);

            updateTask.Status = status;
            updateTask.LastUpdate = DateTime.Now;

            using (var context = GetContext())
            {
                context.TaskHeaders.Update(updateTask);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Создание контекста для работы с БД
        /// </summary>
        /// <returns></returns>
        private AppDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder();
            options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            return new AppDbContext(options.Options);
        }
    }
}
