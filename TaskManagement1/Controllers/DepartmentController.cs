using Microsoft.AspNetCore.Mvc;
using TaskManagement1.Data;
using TaskManagement1.Models;

namespace TaskManagement1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly TaskContextData _dbContext;

        public DepartmentController(TaskContextData dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            var model = _dbContext.Departments.OrderBy(x => x.Id).ToList();
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var department = _dbContext.Departments.Find(id);
            if (department != null)
            {
                _dbContext.Departments.Remove(department);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return View(department);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentModel departmentModel)
        {
            _dbContext.Departments.Add(departmentModel);
            if(_dbContext.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public ActionResult Edit(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return View(department);
        }

        [HttpPost]
        public ActionResult Edit(DepartmentModel departmentModel)
        {
            _dbContext.Departments.Update(departmentModel);
            if(_dbContext.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }
            return View(departmentModel);
        }
    }
}
