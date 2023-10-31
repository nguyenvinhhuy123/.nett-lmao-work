using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _nett_lmao_work.Models
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Student
    {
        public int StudentID {get; set;}
        public string Name {get; set;}
        public DateOnly DateOfBirth {get; set;}
        public string UniversityClass {get; set;}
        public Gender Gender {get;set;}
    }
    public class StudentListViewModel
    {
        public List<Student> _students;

        public StudentListViewModel(List<Student> students)
        {
            _students = students;
        }
    }
}