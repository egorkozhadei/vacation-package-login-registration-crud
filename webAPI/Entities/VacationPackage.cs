using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class VacationPackage
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        public bool IsDeleted { get; set; }
    }
}
