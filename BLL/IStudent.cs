using Tasks.Models;
using Tasks.ViewModels;

namespace Tasks.BLL
{
    public interface IStudent
    {
        public List<Student> GetAll();
        public Student GetByID(int id);
        public Student Add(Student student);
        public void Delete(Student student);
        public void Edit(Student student);
        public List<Student> GetAllStudentsByDeptID(int id);
        public bool IsLoginValid(LoginViewModel model);
        public bool IsEmailUnique(string email);
    }
}
