using BuildReportStatusApi.Enums;
using BuildReportStatusApi.Models;
using TaskStatus = BuildReportStatusApi.Enums.TaskStatus;

namespace BuildReportStatusApi.Repositories
{
    /// <summary>
    /// Работа с сущностью TaskHeader
    /// </summary>
    public interface ITaskHeaderRepository
    {
        /// <summary>
        /// Создание задачи
        /// </summary>
        /// <returns>Новая задача</returns>
        TaskHeader Create();

        /// <summary>
        /// Обновление статуса задачи
        /// </summary>
        /// <param name="id">ИД задачи</param>
        /// <param name="status">Новый статус</param>
        void Update(Guid id, TaskStatus status);

        /// <summary>
        /// Получение задачи по ИД
        /// </summary>
        /// <param name="id">ИД задачи</param>
        /// <returns>Задача</returns>
        TaskHeader GetById(Guid id);
    }
}
