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
            Console.WriteLine(_students.Count);
        }
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new StudentListViewModel(_students);
            return View("Index", viewModel);
        }
        [HttpPost]
        public IActionResult Index([Bind] string CreateStudent)
        {
            if (CreateStudent == "Create")
                return View("Create");
            return View();
        }
        public IActionResult Create(Student student)
        {
            _students.Add(student);
            var viewModel = new StudentListViewModel(_students);
            return View("Index", viewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}