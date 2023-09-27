using Microsoft.AspNetCore.Mvc;
using Task01.ViewModels;
using Tasks.Models;

namespace Tasks.Controllers
{
    public class StudentDepartmentController : Controller
    {
        public ViewResult Index()
        {
            Student st = new Student() { Id = 1, Name = "Ali Elshorpagi", Age = 21 };
            Department dept = new Department() { Id = 103, Name = "CS" };
            StudentDepartmentViewModel viewModel = new StudentDepartmentViewModel { department = dept, student = st };
            ViewBag.viewModel = viewModel;
            return View();
        }
    }
}
