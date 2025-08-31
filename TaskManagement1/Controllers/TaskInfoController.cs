using Microsoft.AspNetCore.Mvc;
using TaskManagement1.Data;
using TaskManagement1.Models;

namespace TaskManagement1.Controllers
{
    public class TaskInfoController : Controller
    {
        private readonly TaskContextData _dbContext;

        public TaskInfoController(TaskContextData dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            // Fixed the issue by casting _dbContext.TaskInfo to the appropriate type  
            var model = ((IQueryable<TaskInfoModel>)_dbContext.Tasks).OrderBy(x => x.Id).ToList();
            return View(model);
        }
    }
}
