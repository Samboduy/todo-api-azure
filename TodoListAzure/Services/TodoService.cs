using TodoListAzure.Models;

namespace TodoListAzure.Services;

public class TodoService
{
    private readonly AppDbContext _dbContext;

    public TodoService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Todo> GetAllTodos()
    {
       return _dbContext.Todos.ToList();
    }

    public void AddTodo(Todo newTodo)
    {
        _dbContext.Todos.Add(newTodo);
        _dbContext.SaveChanges();
    }
    public void DeleteTodo(int id)
    {
        var deleteTodo =  _dbContext.Todos.Find(id);
        if (deleteTodo != null)
        {
            _dbContext.Todos.Remove(deleteTodo);
        }
        _dbContext.SaveChanges();
    }

    public void UpdateTodo(Todo updatedTodo)
    {
        _dbContext.Todos.Update(updatedTodo);
        _dbContext.SaveChanges();
    }
}