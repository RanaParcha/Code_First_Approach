using Code_First_Approach.AppDbContext;
using Code_First_Approach.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Code_First_Approach.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly DataContext _db;
        public HomeController(DataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var emp = _db.Employees.ToList();
            return View(emp);
        }

     

        [HttpGet]
        public IActionResult Employee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Employee(Employee obj)
        {
            _db.Employees.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Privacy");
        }

        public IActionResult DeleteData(int id)
        {
            var emp = _db.Employees.FirstOrDefault(a => a.Id == id);
            _db.Employees.Remove(emp);
            _db.SaveChanges();
            return RedirectToAction("Privacy");      
        }

        [HttpGet]
        public IActionResult UpdateData(int id)
        {
            var emp1 = _db.Employees.FirstOrDefault(a => a.Id == id);
            Employee obj = new Employee();
            obj.Id = emp1.Id;
            obj.Name = emp1.Name;
            obj.Age = emp1.Age;
            obj.Email = emp1.Email;
            obj.Password = emp1.Password;
            return View(obj);
        }

        [HttpPost]
        public IActionResult UpdateData(Employee updatedData)
        {
            _db.Employees.Update(updatedData);
            _db.SaveChanges();
            return RedirectToAction("Privacy");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login (Employee obj)
        {
            var emp = _db.Employees.FirstOrDefault(a=> a.Email == obj.Email && a.Password == obj.Password);
            if (emp != null && emp.Email ==obj.Email && emp.Password == obj.Password)
            {
                return RedirectToAction("Privacy");
            }
            else
            {

                return RedirectToAction("Login");
            }
        }


       public IActionResult Logout()
        {
            return RedirectToAction("Employee");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
