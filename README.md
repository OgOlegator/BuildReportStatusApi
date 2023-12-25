# BuildReportStatusApi

# Задача
Требуется разработать сервис, предоставляющий следующее REST API

1. POST /task
   Без параметров
   Создает запись в БД (любой) со сгенерированным GUID, текущим временем и статусом "created"
   Возвращает клиенту код 202 и GUID задачи
   Обновляет в БД для данного GUID текущее время и меняет статус на "running"
   Ждет 2 минуты
   Обновляет в БД для данного GUID текущее время и меняет статус на "finished"
2. GET /task/{id}
   Параметр id: GUID созданной задачи
   Возвращает код 200 и статус запрошенной задачи:
   {
   }
   Возвращает 404, если такой задачи нет
   Возвращает 400, если передан не GUID

# Используемые технологии
- .Net Core 6
- EF Core
- MsSql

# Запуск приложения
1) Добавить строку подключения в appsettings.json
 
 "ConnectionStrings": {
    "DefaultConnection": "Server={Имя своего сервера БД};Database=BuildReportStatus;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true"
  }

2) В консоли выполнить команду: Update-database
