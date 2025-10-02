using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TodoListAzure.Dto;
using TodoListAzure.Models;
using TodoListAzure.Services;

namespace TodoListAzure.Controllers;

[ApiController]
[Route("/")]
public class TodoController : ControllerBase
{
    private readonly TodoService _todoService;

    public TodoController(TodoService todoService)
    {
        _todoService = todoService;
    }
    
    [HttpGet("/todo")]
    public ActionResult GetAllTodo()
    {
       List<Todo> todos = _todoService.GetAllTodos();
        if (todos.Count == 0)
        {
            return Ok();
        }
        else
        {
            return Ok(todos);
        }
    }

    [HttpPost("/todo/add")]
    public ActionResult AddTodo(TodoDto  todoDto)
    {
        var newTodo = new Todo
        {
            description = todoDto.description,
            done = todoDto.done
        };
        _todoService.AddTodo(newTodo);
        return Ok("added");
    }

    [HttpDelete("/todo/delete")]
    public ActionResult DeleteTodo(int id)
    {
        _todoService.DeleteTodo(id);
        return Ok("deleted todo with id: " + id);
    }

    [HttpPut("/todo/update")]
    public ActionResult UpdateTodo(Todo updatedTodo)
    {
        _todoService.UpdateTodo(updatedTodo);
        return Ok("updated");
    }
}