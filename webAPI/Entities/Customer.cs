using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsDeleted { get; set; }
    }
}
