using Microsoft.AspNetCore.Mvc;
using WebApplicationWithAuth.Models;

namespace WebApplicationWithAuth.Controllers;

public class StudentsController : Controller
{
    public IActionResult GetAll()
    {
        List<Student> students = new List<Student>();

        students.Add(new Student { Name = "Ivan", Age = 20 });
        students.Add(new Student { Name = "Georgi", Age = 30 });
        students.Add(new Student { Name = "Pesho", Age = 35 });

        return View(students);
    }
}
