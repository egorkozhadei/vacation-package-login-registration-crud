using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int Price { get; set; }

        [Required]
        public VacationPackage VacationPackage { get; set; }
        public int VacationPackageId { get; set; }

        [Required]
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        [Required]
        public Manager Manager { get; set; }
        public int ManagerId { get; set; }

        [Required]
        public DateTime CreationDateTime { get; set; }

        [Required]
        public DateTime CompletedDateTime { get; set; }

        public bool IsDeleted { get; set; }
    }
}