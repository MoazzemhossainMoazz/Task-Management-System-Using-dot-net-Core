using Microsoft.AspNetCore.Mvc;
using TaskManagement1.Data;
using TaskManagement1.Models;

namespace TaskManagement1.Controllers
{
    public class AssignTaskController : Controller
    {
        private readonly TaskContextData _dbContext;

        public AssignTaskController(TaskContextData dbContext)
        {
            _dbContext = dbContext;
        }


        public ActionResult Index()
        {
            var model = _dbContext.AssignTasks.OrderBy(x => x.Id).ToList();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var assignTask = _dbContext.AssignTasks.Find(id);
            return View(assignTask);
        }

        public ActionResult Delete(int id)
        {
            var assignTask = _dbContext.AssignTasks.Find(id);
            if (assignTask != null)
            {
                _dbContext.AssignTasks.Remove(assignTask);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AssignTaskModel assignTaskModel)
        {
            _dbContext.AssignTasks.Add(assignTaskModel);
            if (_dbContext.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }
            return View(assignTaskModel);
        }

        public ActionResult Edit(int id)
        {
            var assignTask = _dbContext.AssignTasks.Find(id);
            return View(assignTask);
        }
        [HttpPost]
        public ActionResult Edit(AssignTaskModel assignTaskModel)
        {
            _dbContext.AssignTasks.Update(assignTaskModel);
            if (_dbContext.SaveChanges() > 0)
            {
                return RedirectToAction("Index");
            }
            return View(assignTaskModel);
        }
    }
}
