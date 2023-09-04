using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Data;
using StudentRegistration.Models;

namespace StudentRegistration.Controllers
{
    public class StudentController : Controller
    {
        private AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Student> students = _context.students;
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }


        [HttpPost]
        public IActionResult Create(Student student)
        {
            _context.students.Add(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int? Id)
        {
            var student = _context.students.FirstOrDefault(x => x.Id == Id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Update(Student student)
        {
            _context.students.Update(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            var student = _context.students.FirstOrDefault(x => x.Id == Id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Delete(Student student)
        {
            _context.students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
  }

