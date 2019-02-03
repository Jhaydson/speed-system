using System.ComponentModel.DataAnnotations;

namespace SpeedSystem.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Departamentos")]
        
        public string Name { get; set; }
    }
}