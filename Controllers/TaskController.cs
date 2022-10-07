using Microsoft.AspNetCore.Mvc;
using Test2.Models;

namespace Test2.Controllers
{
    public class TaskController : Controller
    {
        private static List<MyTask> tasks = new List<MyTask>()
        {
            new MyTask() { Id = 1, Description = "Task 1", StatusTask = Status.NotStarted },
            new MyTask() { Id = 2, Description = "Task 2", StatusTask = Status.InProgress },
            new MyTask() { Id = 3, Description = "Task 3", StatusTask = Status.Completed }
        };

        [HttpGet]
        public IActionResult Index()
        {
            return View(tasks);
        }

        [HttpPost]
        public IActionResult Create(String description)
        {
            MyTask task = new MyTask();
            task.Id = tasks.Count + 1;
            task.Description = description;
            task.StatusTask = Status.NotStarted;
            tasks.Add(task);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(long id) {
            MyTask task = tasks.Find(t => t.Id == id);
            if (task.StatusTask == Status.NotStarted) {
                task.StatusTask = Status.InProgress;
            } else if (task.StatusTask == Status.InProgress) {
                task.StatusTask = Status.Completed;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            MyTask task = tasks.Find(t => t.Id == id);
            tasks.Remove(task);
            return RedirectToAction("Index");
        }
        
    }
}