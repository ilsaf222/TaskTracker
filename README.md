# TaskTracker
## ASP.NET Core WebApi & Swagger UI
___
![Microsoft.EntityFrameworkCore](https://img.shields.io/nuget/v/Microsoft.EntityFrameworkCore?label=Microsoft.EntityFrameworkCore)
![Microsoft.EntityFrameworkCore.Design](https://img.shields.io/nuget/v/Microsoft.EntityFrameworkCore.Design?label=Microsoft.EntityFrameworkCore.Design)
![Npgsql.EntityFrameworkCore.PostgreSQL](https://img.shields.io/nuget/v/Npgsql.EntityFrameworkCore.PostgreSQL?label=Npgsql.EntityFrameworkCore.PostgreSQL)
![AutoMapper](https://img.shields.io/nuget/v/AutoMapper?label=AutoMapper)

In this repository, I want to show a simple example implementation on how to create a **WebAPI** using **ASP.NET Core**.
Any IDE will do for running the project. For example: **VS Code, VIsual Studio**, and you need **PostgreSql** for the database.
This project contains a three-level architecture (data access level, logic level, representation).

### Features:
<ul>
<li>Ability to create / view / edit / delete information about projects</li>
<li>Ability to create / view / edit / delete task information</li>

<li>Ability to add and remove tasks from a project (one project can contain several tasks)</li>
<li>Ability to view all tasks in the project</li>
<li>Have an ability to filter and sort projects with various methods (start at, end at, range, exact value, etc.) and by various fields (start date, priority, etc.)</li>
</ul>