using System.ComponentModel.DataAnnotations;

namespace AbyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name="Display Order")]
        [Range(1, 100, ErrorMessage ="Display order must be greater than 0, but cannot exceed 100.")]
        public int DisplayOrder { get; set; }

    }
}
