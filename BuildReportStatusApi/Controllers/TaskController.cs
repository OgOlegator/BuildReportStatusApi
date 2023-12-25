using BuildReportStatusApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using TaskStatus = BuildReportStatusApi.Enums.TaskStatus;

namespace BuildReportStatusApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskHeaderRepository _headerRepository;

        public TaskController(ITaskHeaderRepository headerRepository)
        {
            _headerRepository = headerRepository;
        }

        /// <summary>
        /// Запуск задачи
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("task")]
        public IResult Start()
        {
            var taskHeader = _headerRepository.Create();

            var buildTask = Task.Run(() => BuildReport(taskHeader.Id));

            return Results.Accepted(value: taskHeader.Id);
        }

        /// <summary>
        /// Получение статуса задачи
        /// </summary>
        /// <param name="id">ИД задачи</param>
        /// <returns></returns>
        [HttpGet]
        [Route("task/{id}")]
        public IResult GetStatus(string id)
        {
            try
            {
                var result = _headerRepository.GetById(Guid.Parse(id));

                return Results.Ok(result.Status.ToString());
            }
            catch (KeyNotFoundException)
            {
                return Results.NotFound();
            }
            catch(Exception)
            {
                return Results.BadRequest();
            }
        }

        /// <summary>
        /// Процесс выполнения задачи
        /// </summary>
        /// <param name="id"></param>
        private void BuildReport(Guid id)
        {            
            _headerRepository.Update(id, TaskStatus.Running);
            Thread.Sleep(120000); 
            _headerRepository.Update(id, TaskStatus.Finished);
        }
    }
}
