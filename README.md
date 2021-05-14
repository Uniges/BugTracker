# Web Application, «Bug Tracker»
 
**• ASP.NET Core 3.1, Web API, RESTful, JWT • Entity Framework Core, Code first, PostgreSQL • Clean Architecture •**

**• Swagger: https://localhost:5001/swagger/ (Alex55 123) •**

**• Postgre settings: https://github.com/Uniges/BugTracker/blob/master/WebApp/appsettings.json •**

Прототип системы учета ошибок, обнаруженных в процессе тестирования программного обеспечения.

Пароли хэшируются, тестовые данные и пользователи запишутся в базу при первой попытке обращения к любому из API.

Для работы API необходим JWT токен.

# Возможности: 

/Users/auth - авторизация, получение JWT токена (Alex55 123, Li77 321)

/Users/edit - редактирование имени и/или фамилии пользователя

/Bugs/{id} - получить баг по ID

/Bugs - получить все баги

/Bugs/sort - получить все баги, отсортированные по выбранному полю и направлению сортировки

/Bugs/create - создание бага (автоматически создается первая запись в истории, время выставляется автоматически)

/Bugs/edit - редактирование статуса бага (автоматически создается запись в истории, время автоматически)

/Bugs/history/{id} - получение истории бага, отсортированная по дате внесения изменений

![Image alt](https://i.imgur.com/UalwHB2.png)
