using Microsoft.AspNetCore.Mvc;
using TaskManagement1.Data;
using TaskManagement1.Models;

namespace TaskManagement1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly TaskContextData _dbContext;
        public EmployeeController(TaskContextData dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult Index()
        {
            var model = _dbContext.Employees.OrderBy(x => x.Id).ToList();
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            return View(employee);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(EmployeeModel employee)
        {
            if (ModelState.IsValid)
            {
                if (employee.Picture != null)
                {
                    string fileName = Path.GetFileName(employee.Picture.FileName);
                    string extension = Path.GetExtension(fileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "picture", employee.Name + extension);

                    if (extension != ".jpg" && extension != ".png" && extension != "jpeg")
                    {
                        ModelState.AddModelError("Picture", "Only .jpg, .png, .jpeg file are allowed");
                        return View(employee);
                    }
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        employee.Picture.CopyTo(stream);
                    }
                    employee.PicturePath = "/Picture/" + employee.Name + extension;

                    _dbContext.Employees.Add(employee);
                    if (_dbContext.SaveChanges() > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage
                        ));
                        ModelState.AddModelError(" ", message);
                        return View(employee);
                    }
                }
                return View();
            }
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                if (employeeModel.Picture != null)
                {
                    string fileName = Path.GetFileName(employeeModel.Picture.FileName);
                    string extension = Path.GetExtension(fileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "picture", employeeModel.Name + extension);

                    if (extension != ".jpg" && extension != ".png" && extension != "jpeg")
                    {
                        ModelState.AddModelError("Picture", "Only .jpg, .png, .jpeg file are allowed");
                        return View(employeeModel);
                    }
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        employeeModel.Picture.CopyTo(stream);
                    }
                    employeeModel.PicturePath = "/Picture/" + employeeModel.Name + extension;

                    _dbContext.Employees.Update(employeeModel);
                    if (_dbContext.SaveChanges() > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage
                        ));
                        ModelState.AddModelError(" ", message);
                        return View(employeeModel);
                    }
                }
                return View();
            }
            return View(employeeModel);
        }

    }
}
