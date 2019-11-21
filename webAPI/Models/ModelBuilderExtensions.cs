using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<Manager>().HasIndex(c => c.Username).IsUnique();

            modelBuilder.Entity<VacationPackage>().HasData(new List<VacationPackage>
            {
                new VacationPackage
                {
                    Id = 1,
                    Name = "Турция, отель 5 звезд",
                    Price = 20000
                },
                new VacationPackage
                {
                    Id = 2,
                    Name = "Альпы, отель 5 звезд",
                    Price = 300000
                },
                new VacationPackage
                {
                    Id = 3,
                    Name = "Сочи, отель 2 звезды",
                    Price = 1000
                }
            });

            modelBuilder.Entity<Customer>().HasData(new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Email = "vasya@mail.ru",
                    FullName = "Вася",
                    PhoneNumber = "88005553535"
                },
                new Customer
                {
                    Id = 2,
                    Email = "peterthefirst@gmail.com",
                    FullName = "Петя",
                    PhoneNumber = "9922623447"
                },
                new Customer
                {
                    Id = 3,
                    Email = "galina177@yandex.ru",
                    FullName = "Галя",
                    PhoneNumber = "88005553535"
                },
            });

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            modelBuilder.Entity<Manager>().HasData(new List<Manager>
            {
                new Manager
                {
                    Id = 1,
                    FirstName = "Manage",
                    LastName = "Ment",
                    Username = "manager",
                    PasswordSalt = hmac.Key,
                    PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("manager"))
                }
            });

            modelBuilder.Entity<Order>().HasData(new List<Order>
            {
                new Order
                {
                    Id = 1,
                    Price = 500,
                    VacationPackageId = 1,
                    CustomerId = 1,
                    ManagerId = 1,
                    CreationDateTime = DateTime.Now,
                    CompletedDateTime = DateTime.Now
                },
                new Order
                {
                    Id = 2,
                    Price = 600,
                    VacationPackageId = 2,
                    CustomerId = 2,
                    ManagerId = 1,
                    CreationDateTime = DateTime.Now,
                    CompletedDateTime = DateTime.Now
                },
                new Order
                {
                    Id = 3,
                    Price = 700,
                    VacationPackageId = 3,
                    CustomerId = 3,
                    ManagerId = 1,
                    CreationDateTime = DateTime.Now,
                    CompletedDateTime = DateTime.Now
                }
            });
        }
    }
}