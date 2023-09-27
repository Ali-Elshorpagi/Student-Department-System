using Tasks.Models;

namespace Task01.ViewModels
{
    public class StudentDepartmentViewModel
    {
        public Student student { get; set; }
        public Department department { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
