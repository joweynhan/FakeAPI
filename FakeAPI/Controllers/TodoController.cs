using FakeAPI.Models;
using FakeAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace FakeAPI.Controllers
{
    public class TodoController : Controller
    {
        ITodoRepository _repo;
        public TodoController(ITodoRepository repo)
        {
            this._repo = repo;
        }
        public IActionResult GetAllTodo()
        {
            var todolist = _repo.GetAllTodo();
            return View(todolist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todo newTodo)
        {
            if (ModelState.IsValid)
            {
                var todo = _repo.AddTodo(newTodo);
                return RedirectToAction("GetAllTodo");
            }
            ViewData["Message"] = "Data is not valid to create the todo.";
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var todo = _repo.GetTodoById(id);
            return View(todo);
        }

        [HttpGet]
        public IActionResult Update(int todoId)
        {
            var oldTodo = _repo.GetTodoById(todoId);
            return View(oldTodo);
        }

        [HttpPost]
        public IActionResult Update(Todo newTodo)
        {
            var todo = _repo.UpdateTodo(newTodo.Id, newTodo);
            return RedirectToAction("GetAllTodo");
        }
        public IActionResult Delete(int id)
        {
            var todoList = _repo.DeleteTodo(id);
            return RedirectToAction(controllerName: "Todo", actionName: "GetAllTodo");
        }
    }
}
