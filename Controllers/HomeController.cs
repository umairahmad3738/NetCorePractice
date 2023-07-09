using Microsoft.AspNetCore;
using kudvenkitPractice.Models;
using kudvenkitPractice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using kudvenkitPractice.Repositories;
namespace kudvenkitPractice.Controllers
{

    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository,
                             IWebHostEnvironment hostingEnvironment)//this interface was used to get wwwroot folder path
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment; 
        }

        [Route("")]
        [Route("home")]
        [Route("home/index")]
        public ViewResult Index()
        {
            ViewBag.Title = "Employee Details";
            var employee = _employeeRepository.GetAllEmployees();
            return View(employee);
        }
        [Route("Home/Details/{id?}")] //Attribute Routing
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel EmployeeViewDetails = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(id ?? 1),
                PageTitle = "Employee Details"
            };

            return View(EmployeeViewDetails);
        }
        [Route("Home/DeleteEmployee/{id?}")] //Attribute Routing
        public ViewResult DeleteEmployee(int? id)
        {
            var updatedEmployees = _employeeRepository.DeleteEmployee(id);
            return View("Index", updatedEmployees);
        }
        [HttpGet]
        [Route("Home/CreateEmployee/{id?}")] //Attribute Routing
        public ViewResult CreateEmployee()
        {
            return View("Views/Home/CreateEmployee.cshtml");
        }

        [HttpPost]
        [Route("Home/CreateEmployee/{id?}")] //Attribute Routing
        public ActionResult CreateEmployee(EmployeeCreateViewModel  emp)
        {
            if (ModelState.IsValid) //Validation
            {
                string uniqueFileName = null;
                if (emp.Photo != null)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + emp.Photo.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);
                    emp.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Employee newEmployee = new Employee
                {
                    Name = emp.Name,
                    Gender = emp.Gender,
                    Email = emp.Email,
                    Department = emp.Department,
                    PhotoPath = uniqueFileName
                };
                _employeeRepository.CreateEmployee(newEmployee);
                return RedirectToAction("details", new { id = newEmployee.Id });
            }
            return View();
        }
        [HttpGet]
        [Route("Home/EditEmployee/{id?}")]
        public ActionResult UpdateEmployee(int id)
        {
            Employee emp = _employeeRepository.GetEmployee(id);
            if (emp != null && !emp.Equals(_employeeRepository.UpdateEmployee(emp)))
            {
                return RedirectToAction("details", new { id = emp.Id });
            }
            return View();
        }
    }
}
