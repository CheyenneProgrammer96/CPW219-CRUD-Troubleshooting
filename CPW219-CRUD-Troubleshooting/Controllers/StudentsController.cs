using CPW219_CRUD_Troubleshooting.Data;
using CPW219_CRUD_Troubleshooting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPW219_CRUD_Troubleshooting.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext context;

        public StudentsController(SchoolContext dbContext)
        {
            context = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            List<Student> students = await (from student in context.Students
                                            select student).ToListAsync();
            
            
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student stu)
        {
            if (ModelState.IsValid)
            {
                context.Students.Add(stu);
                await context.SaveChangesAsync();

                ViewData["Message"] = $"{stu.Name} was added successfully!";
                return View();
            }

            //Show web page with errors
            return View(stu);
        }

        public async Task<IActionResult> Edit(int id)
        {
            //get the product by id
            Student? stuToEdit = await context.Students.FindAsync(id);

            if (stuToEdit == null) 
            {
                return NotFound();
            }

            //show it on web page
            return View(stuToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student stuModel)
        {
            if (ModelState.IsValid)
            {
                context.Students.Update(stuModel);
                await context.SaveChangesAsync();

                ViewData["Message"] = $"{stuModel.Name} was updated successfully!";
                return RedirectToAction("Index");
            }
            //return view with errors
            return View(stuModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Student? stuToDelete = await context.Students.FindAsync(id);

            if (stuToDelete == null) 
            { 
                return NotFound();
            }
            
            return View(stuToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            //Get Product from database
            Student? stuToDelete = await context.Students.FindAsync(id);

            if (stuToDelete != null)
            {
                context.Students.Remove(stuToDelete);
                await context.SaveChangesAsync();
                TempData["Message"] = stuToDelete.Name + "was deleted successfully!";
                return RedirectToAction("Index");
            }

            TempData["Message"] = "This student was already deleted";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            Student? stuDetails = await context.Students.FindAsync(id);

            if (stuDetails == null) 
            {
                return NotFound();
            }

            return View(stuDetails);
        }
    }
}
