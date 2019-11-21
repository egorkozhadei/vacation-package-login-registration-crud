using System;

namespace WebApi.Models.Dtos
{
    public class OrderInputDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int VacationPackageId { get; set; }
        public int ManagerId { get; set; }
        public int Price { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime CompletedDateTime { get; set; }
    }
}
