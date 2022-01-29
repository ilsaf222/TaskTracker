using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Entities;

namespace TaskTracker.DataBase
{
    public class TaskTrackerContext : DbContext
    {
        public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Objective> Objectives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var dateTime = DateTime.UtcNow;

            modelBuilder.Entity<Project>().HasData( //инициализация БД начальными даннымм (Initialize the database with the initial data)
                new Project[]
                {
                new Project { Id = 1, Name = "Car Tracker", Description = "Реализовать проект по отслеживанию машин", Priority = 50, Status = Domain.Enums.ProjectStatus.NotStarted,
                    StartTime = dateTime, EndTime = dateTime.AddDays(7)},

                new Project { Id = 2, Name = "Task Tracker", Description = "Реализовать Web API для внесения данных о проекте в базу данных", Priority = 100, Status = Domain.Enums.ProjectStatus.Active,
                    StartTime = dateTime, EndTime = dateTime.AddDays(3)},

                new Project { Id = 3, Name = "Интернет магазин", Description = "Создать сайт для интернет магазина", Priority = 100, Status = Domain.Enums.ProjectStatus.NotStarted,
                    StartTime = dateTime, EndTime = dateTime.AddDays(30)},
                });

            modelBuilder.Entity<Objective>().HasData( //инициализация БД начальными даннымм (Initialize the database with the initial data)
                new Objective[]
                {
                new Objective { Id = 1, Name = "Создать сортировку по товару", Description = "Сортировка для быстрого поиска товара по цене",
                    Priority = 70, Status = TaskStatus.WaitingForActivation, ProjectId = 3},

                new Objective { Id = 2, Name = "Поиск", Description = "Улучшить работу поиска",
                    Priority = 30, Status = TaskStatus.RanToCompletion, ProjectId = 3},

                new Objective { Id = 3, Name = "Разделить по категориям", Description = "Разделить товары по категорям",
                    Priority = 100, Status = TaskStatus.RanToCompletion, ProjectId = 3},

                new Objective { Id = 4, Name = "Точность отслеживания", Description = "Улучшить точность отслеживания машины",
                    Priority = 90, Status = TaskStatus.Running, ProjectId = 1},

                new Objective { Id = 5, Name = "НАчальные данные", Description = "СДелать инициализацию БД начальными даннымм",
                    Priority = 100, Status = TaskStatus.Running, ProjectId = 2},

                });
        }
    }
}
