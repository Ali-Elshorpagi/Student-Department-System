using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        //[Display(Name = "Full Name")]
        [StringLength(20, MinimumLength = 3), Required(ErrorMessage ="\tAt Least 3 char, At Most 20 char")]
        public string Name { get; set; }
        [Range(15, 40, ErrorMessage = "\t*")]
        public int Age { get; set; }
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}", ErrorMessage = "\tEmail does not match the pattern")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="*"), StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //[Display(Name = "Confirm Password")]
        [Compare("Password")]
        [NotMapped]
        [DataType(DataType.Password)]
        public string CPassword { get; set; }
        [ForeignKey("Department")]
        //[Display(Name="Department")]
        public int? DeptId { get; set; }
        public virtual Department Department { get; set; }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}, Email: {Email}";
        }
    }
}
