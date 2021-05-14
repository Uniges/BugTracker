# Web Application, «Bug Tracker»
 
**• ASP.NET Core 3.1, Web API, RESTful, JWT • Entity Framework Core, Code first, PostgreSQL • Clean Architecture •**

**• Swagger: https://localhost:5001/swagger/ (Alex55 123) •**

**• Postgre settings: https://github.com/Uniges/BugTracker/blob/master/WebApp/appsettings.json •**

Прототип системы учета ошибок, обнаруженных в процессе тестирования программного обеспечения.

Пароли хэшируются, тестовые данные и пользователи запишутся в базу при первой попытке обращения к любому из API.

Для работы API необходим JWT токен.

# Возможности: 

/Users/auth - авторизация, получение JWT токена (Alex55 123, Li77 321)
```json
{
    "Login": "Alex55",
    "Password": "123"
}
```
/Users/edit - редактирование имени и/или фамилии пользователя
```json
{
    "UserId": 1,
    "Name" : "George",
    "LastName": "P"
}
```
/Bugs/{id} - получить баг по ID

/Bugs - получить все баги

/Bugs/sort - получить все баги, отсортированные по выбранному полю и направлению сортировки
```json
{
    "FieldName": "datE",
    "IsSortByDesc": false
}
```
```C#
public class Bug
{
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public BugStatus Status { get; set; }
    public BugUrgency Urgency { get; set; }
    public BugCriticality Criticality { get; set; }
}
```
/Bugs/create - создание бага (автоматически создается первая запись в истории, время выставляется автоматически)
```json
{
    "title": "New bug",
    "description": "Some description",
    "urgency": 2,
    "criticality": 1,
    "comment": "Init new bug"
}
```
```C#
public enum BugCriticality
{
    Alarm,
    Critical,
    NonCritical,
    ChangeRequest
}

public enum BugUrgency
{
    High,
    Medium,
    Low,
    None
}
```
/Bugs/edit - редактирование статуса бага (автоматически создается запись в истории, время автоматически)
```json
{
    "BugId": 1,
    "BugStatus": 1,
    "Comment": "Open the bug"
}
```
```C#
public enum BugStatus
{
    New,
    Opened,
    Fixed,
    Closed
}

public enum BugAction
{
    Input,
    Open,
    Solution,
    Close
}
```
/Bugs/history/{id} - получение истории бага, отсортированной по дате внесения изменений

![Image alt](https://i.imgur.com/UalwHB2.png)
