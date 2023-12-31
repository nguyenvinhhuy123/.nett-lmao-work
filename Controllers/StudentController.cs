using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using _nett_lmao_work.Models;



namespace _nett_lmao_work.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {
        public static List<Student> _students= new List<Student>();
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
            Student newStudent = new Student();
        }
        [ActionName("Index")]
        [HttpGet]
        public IActionResult Index([Bind] Student student)
        {
            if (student != null)
            {   
                _students.Add(student);
            }
            var viewModel = new StudentListViewModel(_students);
            Console.WriteLine(viewModel._students);
            Console.WriteLine(_students.Count);
            return View("Index", viewModel);
        }
        public IActionResult Add([Bind] string CreateStudent)
        {
            if (CreateStudent == "Create")
                return RedirectToAction("Create", "Student");
            return View();
        }
        [ActionName("Create")]
        [HttpPost]
        public IActionResult Create()
        {
            Console.WriteLine("add");
            return View("Create");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}