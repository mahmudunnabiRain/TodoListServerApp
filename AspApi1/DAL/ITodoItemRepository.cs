using TodoListServerApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListServerApp.DAL
{
    public interface ITodoItemRepository : IDisposable
    {
        Task<List<TodoItem>> GetTodoItemsAsync();
        
        Task<TodoItem> GetTodoItemByIdAsync(long todoId);

        Task<TodoItem> InsertTodoItemAsync(TodoItem todoItem);

        Task<TodoItem> DeleteTodoItemAsync(TodoItem todoItem);

        Task<TodoItem> UpdateStudentAsync(TodoItem todoItem);

        bool TodoItemExists(long todoId);

    }
}
