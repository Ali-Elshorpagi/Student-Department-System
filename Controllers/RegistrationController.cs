using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tasks.BLL;
using Tasks.Models;
using Tasks.ViewModels;

namespace Tasks.Controllers
{
    public class RegistrationController : Controller
    {
        StudentBLL stBll = new StudentBLL();
        DepartmentBLL deptBLL = new DepartmentBLL();
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (stBll.IsLoginValid(model))
                {
                    TempData["NotValid"] = "The password or email is incorrect";
                    return RedirectToAction("Login");
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Depts = new SelectList(deptBLL.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Register(Student student)
        {
            if (ModelState.IsValid)
            {
                if (stBll.IsEmailUnique(student.Email))
                {
                    stBll.Add(student);
                    return RedirectToAction("Index", "Home");
                }
                else { ModelState.AddModelError("Email", "Email address is already exists"); }
            }
            ViewBag.Depts = new SelectList(deptBLL.GetAll(), "Id", "Name");
            return View(student);
        }
    }
}
