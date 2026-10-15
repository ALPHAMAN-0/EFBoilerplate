using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFBoilerplate.Models
{
    [Table("students")]
    public class Student
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; } = "";

        [Required(ErrorMessage = "Department is required")]
        public string dept { get; set; } = "";

        public float? cgpa { get; set; }
    }
}
