using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApplication2.Data;
using WebApplication2.Models;
using WebApplication2.Models.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication2.Controllers
{

    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed,
                Date = viewModel.Date,
                Capacity = viewModel.Capacity,
                Visiting_Hour = viewModel.Visiting_Hour,
                Price = viewModel.Price,
                Description = viewModel.Description,
                Location = viewModel.Location
            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            //dbContext.SaveChanges();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            return View(student);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student ViewModel)
        {
            var student = await dbContext.Students.FindAsync(ViewModel.Id);
            if (student != null)
            {

                student.Name = ViewModel.Name;
                student.Email = ViewModel.Email;
                student.Phone = ViewModel.Phone;
                student.Subscribed = ViewModel.Subscribed;
                student.Date = ViewModel.Date;
                student.Capacity = ViewModel.Capacity;
                student.Visiting_Hour = ViewModel.Visiting_Hour;
                student.Price = ViewModel.Price;
                student.Description = ViewModel.Description;
                student.Location = ViewModel.Location;
                await dbContext.SaveChangesAsync();


            }
            return RedirectToAction("List", "Students");

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student ViewModel)
        {
            var student = await dbContext.Students.FindAsync(ViewModel.Id);
            if (@student!= null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync(true);
            }
            return RedirectToAction("List", "Students");
        }
        //[HttpGet]
        //public async Task<IActionResult> Search(string searchString)
        //{
        //    // Query to get all students from the database
        //    var studentsQuery = dbContext.Students.AsQueryable();

        //    // If a search string is provided, filter the students based on the search string
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        studentsQuery = studentsQuery.Where(s => s.Name.Contains(searchString) ||
        //           s.Id.ToString().Contains(searchString) ||
        //            s.Email.Contains(searchString));
        //    }

        //    // Execute the query and get the filtered list
        //    var students = await studentsQuery.ToListAsync();

        //    // Pass the filtered list to the view
        //    return View(students);
        //}
        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            List<Student> students;

            if (string.IsNullOrEmpty(searchString))
            {
                // If no search string is provided, return all students
                students = await dbContext.Students.ToListAsync();
            }
            else
            {
                
                students = await dbContext.Students
                    .Where(s => s.Name.Contains(searchString) || s.Email.Contains(searchString))
                    .ToListAsync();

              
                if (students.Count == 0)
                {
                    TempData["warning"] = "No students found matching your search criteria.";
                }
            }

            ViewData["searchString"] = searchString;

            // Return the filtered list to the view
            return View("List", students); 
        }




    }
}