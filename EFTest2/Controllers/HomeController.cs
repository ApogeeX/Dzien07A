using EFTest2.Data;
using EFTest2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFTest2.Controllers
{
    public class HomeController : Controller 
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IList<Employee> employees = _dbContext.Employees.ToList();

            //_dbContext.Employees.Add(new Employee());
            //_dbContext.SaveChanges();
            return View(employees);
        }

        public IActionResult Details(int id)
        {
            var employee = _dbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            var employee = _dbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            //update
            var p = _dbContext.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
            if (p == null)
            {
                return NotFound();
            }
            _dbContext.Employees.Remove(p);
            _dbContext.Employees.Add(employee);
            //_dbContext.Employees.Add(new Employee());
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var p = _dbContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (p == null)
            {
                return NotFound();
            }
            return View(p);

        }

        [HttpPost]
        public IActionResult DeleteConfirmed(Employee employee)
        {
            var p = _dbContext.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
            if (p == null)
            {
                return NotFound();
            }

            _dbContext.Employees.Remove(p);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            int x = 0;
            if (_dbContext.Employees.Count() == 0)
            {
                x = 1;
            }
            else
            {
                x = _dbContext.Employees.Max(x => x.Id) + 1;
            }
            var p = new Employee { Id = x, Email = "", Name = "", Address="" };
            return View(p);
        }

        public IActionResult CreateConfirmed(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}