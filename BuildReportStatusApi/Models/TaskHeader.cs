using BuildReportStatusApi.Enums;
using System.ComponentModel.DataAnnotations;
using TaskStatus = BuildReportStatusApi.Enums.TaskStatus;

namespace BuildReportStatusApi.Models
{
    public class TaskHeader
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime LastUpdate { get; set; }

        public TaskStatus Status { get; set; }
    }
}
