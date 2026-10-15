using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFBoilerplate.Models
{
    [Table("employees")]
    public class Employee
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string email { get; set; } = "";

        [Required(ErrorMessage = "Name is required")]
        public string name { get; set; } = "";

        [Required(ErrorMessage = "Designation is required")]
        public string designation { get; set; } = "";

        public int? age { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public int salary { get; set; }
    }
}
