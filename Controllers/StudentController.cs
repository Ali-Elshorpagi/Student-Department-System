using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tasks.ActionFilters;
using Tasks.BLL;
using Tasks.Models;

namespace Tasks.Controllers
{
    [ExceptionsHandler]
    public class StudentController : Controller
    {
        StudentBLL stBll = new StudentBLL();
        DepartmentBLL deptBLL = new DepartmentBLL();
        public ViewResult Index(string searchType, string searchQuery, bool sort)
        {
            var students = stBll.GetAll();
            ViewBag.isExist = false;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                if (searchType == "Name")
                    students = students.Where(st => st.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
                else if (searchType == "ID")
                {
                    if (int.TryParse(searchQuery, out int id))
                        students = students.Where(st => st.Id == id).ToList();
                }
            }
            if(sort == true)
                students = students.OrderBy(st => st.Name).ToList();
            if(students.Count != 0)
                ViewBag.isExist = true;
            ViewBag.SearchQuery = searchQuery;
            return View(students);
        }
        public IActionResult Details(int? id)
        {
            if (id is null) // if the user doesn't enter any id
                return BadRequest();
            var student = stBll.GetByID(id.Value);
            if (student is null) // there is no student has this 'id'
                return NotFound();
            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Depts = new SelectList(deptBLL.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                if (stBll.IsEmailUnique(student.Email))
                {
                    stBll.Add(student);
                    return RedirectToAction("Index", "Student");
                }
                else { ModelState.AddModelError("Email", "Email address is already exists"); }
            }
            ViewBag.Depts = new SelectList(deptBLL.GetAll(), "Id", "Name");
            return View(student);
        }
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            Student std = stBll.GetByID(id.Value);
            if (std is null)
                return NotFound();
            stBll.Delete(std);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id is null)
                return BadRequest();
            Student std = stBll.GetByID(id.Value);
            if (std is null)
                return NotFound();
            ViewBag.Depts = new SelectList(deptBLL.GetAll(), "Id", "Name", std.DeptId);
            return View(std);
        }
        [HttpPost]
        public IActionResult Update(Student std)
        {
            stBll.Edit(std);
            return RedirectToAction("Index");
        }
    }
}