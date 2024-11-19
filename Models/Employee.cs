using System.ComponentModel.DataAnnotations;

namespace Code_First_Approach.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string ?Name { get; set; }
        public int Age { get; set; }
        public string ?Email { get; set; }
        public string ?Password { get; set; }
    }
}
