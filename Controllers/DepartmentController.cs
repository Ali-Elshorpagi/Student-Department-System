using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task01.ViewModels;
using Tasks.ActionFilters;
using Tasks.BLL;
using Tasks.Models;

namespace Tasks.Controllers
{
    [ExceptionsHandler]
    public class DepartmentController : Controller
    {
        DepartmentBLL deptBll = new DepartmentBLL();
        StudentBLL stBll = new StudentBLL();
        public ViewResult Index(string searchType, string searchQuery, bool sort)
        {
            var departments = deptBll.GetAll();
            ViewBag.isExist = false;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                if (searchType == "Name")
                    departments = departments.Where(st => st.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)).ToList();
                else if (searchType == "ID")
                {
                    if (int.TryParse(searchQuery, out int id))
                        departments = departments.Where(st => st.Id == id).ToList();
                }
            }
            if (sort == true)
                departments = departments.OrderBy(st => st.Name).ToList();
            if (departments.Count != 0)
                ViewBag.isExist = true;
            ViewBag.SearchQuery = searchQuery;
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department dept)
        {
            deptBll.Add(dept);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();

            Department dept = deptBll.GetByID(id.Value);

            if (dept is null)
                return NotFound();

            deptBll.Delete(dept);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id is null)
                return BadRequest();
            Department dpt = deptBll.GetByID(id.Value);
            if (dpt is null)
                return NotFound();
            return View(dpt);
        }
        [HttpPost]
        public IActionResult Update(Department dept)
        {
            deptBll.Edit(dept);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            var students = stBll.GetAllStudentsByDeptID(id.Value);
            var dept = deptBll.GetByID(id.Value);
            if (dept is null)
                return NotFound();
            var viewModel = new StudentDepartmentViewModel() { Students = students, department = dept };
            ViewBag.viewModel = viewModel;
            return View();
        }
    }
}
