using Microsoft.EntityFrameworkCore;
using Tasks.Contexts;
using Tasks.Models;
using Tasks.ViewModels;

namespace Tasks.BLL
{
    // Repository Design Pattern
    public class StudentBLL : IStudent
    {
        SchoolContext db = new SchoolContext();
        public List<Student> GetAll()
        {
            return db.Students.Include(s => s.Department).ToList();
        }
        public Student GetByID(int id)
        {
            return db.Students.Include(d => d.Department).SingleOrDefault(st => st.Id == id);
        }
        public Student Add(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return student;
        }
        public void Delete(Student student)
        {
            db.Students.Remove(student);
            db.SaveChanges();
        }
        public void Edit(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }
        public List<Student> GetAllStudentsByDeptID(int id)
        {
            return db.Students.Where(d => d.DeptId == id).ToList();
        }
        public bool IsLoginValid(LoginViewModel model)
        {
            var student = db.Students.SingleOrDefault(st => st.Email == model.Username && st.Password == model.Password);
            return student == null;
        }
        public bool IsEmailUnique(string email)
        {
            var student = db.Students.SingleOrDefault(st => st.Email == email);
            return student == null;
        }
    }
}
