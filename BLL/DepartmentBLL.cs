using Microsoft.EntityFrameworkCore;
using Tasks.Contexts;
using Tasks.Models;

namespace Tasks.BLL
{
    public class DepartmentBLL
    {
        SchoolContext db = new SchoolContext();
        public List<Department> GetAll()
        {
            return db.Departments.Include(st => st.Students).ToList();
        }
        public Department Add(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();
            return dept;
        }
        public Department GetByID(int id)
        {
            return db.Departments.Include(st => st.Students).SingleOrDefault(d => d.Id == id);
        }
        public void Delete(Department dept)
        {
            db.Departments.Remove(dept);
            db.SaveChanges();
        }
        public void Edit(Department dept)
        {
            db.Departments.Update(dept);
            db.SaveChanges();
        }
    }
}
