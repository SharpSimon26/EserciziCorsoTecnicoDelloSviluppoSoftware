using Todo.DataAccess.DTO;
using Todo.DataAccess.Models.Entities;

namespace Todo.DataAccess.Repositories;

public interface ITodoRepository
{
    Task<IEnumerable<TodoItem>> GetAllAsync();
    Task<TodoItem?> GetTodoByIdAsync(int id);
    Task<TodoItem?> CreateTodoAsync(TodoCreateDTO dto);
    Task<TodoItem?> UpdateTodoAsync(TodoUpdateDTO dto);
    Task<TodoItem?> ChangeTodoAsync(TodoChangeDTO dto);
    Task<bool> DeleteTodoByIdAsync(int id);
}