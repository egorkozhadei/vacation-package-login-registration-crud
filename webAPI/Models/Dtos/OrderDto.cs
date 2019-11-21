using System;
using WebApi.Models.Users;

namespace WebApi.Models.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public CustomerDto Customer { get; set; }
        public VacationPackageDto VacationPackage { get; set; }
        public ManagerModel Manager { get; set; }
        public int Price { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime CompletedDateTime { get; set; }
    }
}