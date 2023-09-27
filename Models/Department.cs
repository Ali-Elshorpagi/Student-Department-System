using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Tasks.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required, StringLength(10)]
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
        public Department()
        {
            Students = new HashSet<Student>();
        }
        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}";
        }
    }
}
