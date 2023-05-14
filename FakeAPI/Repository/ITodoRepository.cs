using FakeAPI.Models;

namespace FakeAPI.Repository
{
    public interface ITodoRepository
    {
        List<Todo> GetAllTodo();
        Todo GetTodoById(int id);
        Todo AddTodo(Todo newTodo);
        Todo UpdateTodo(int id, Todo newTodo);
        Todo DeleteTodo(int id);
    }
}
