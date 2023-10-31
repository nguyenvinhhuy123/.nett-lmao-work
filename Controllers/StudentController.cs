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
        public List<Student> _students;
        private readonly ILogger<StudentController> _logger;
        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
            Student newStudent = new Student();
            _students= new List<Student>();
            newStudent.StudentID = 0;
            newStudent.Name = "Honk";
            newStudent.UniversityClass = "CLC";
            newStudent.Gender = Gender.Female;
            newStudent.DateOfBirth = new DateOnly(2000, 1, 21);
            _students.Add(newStudent);
            Console.WriteLine(_students.Count);
        }
        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new StudentListViewModel(_students);
            return View("Index", viewModel);
        }
        // [HttpGet]
        // public IActionResult Create()
        // {
        //     return Index();
        // }
        // [HttpPost]
        // public IActionResult Create(Student student)
        // {
        //     _students.Append(student);
        //     return Index();
        // }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}