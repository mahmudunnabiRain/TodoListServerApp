using TodoListServerApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListServerApp.DAL
{
    public class TodoItemRepository : ITodoItemRepository, IDisposable
    {

        private readonly TodoContext _context;
        public TodoItemRepository(TodoContext context)
        {
            this._context = context;
        }


        public async Task<TodoItem> DeleteTodoItemAsync(TodoItem todoItem)
        {
            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }

        public async Task<TodoItem> GetTodoItemByIdAsync(long todoId)
        {
            return await _context.TodoItems.FindAsync(todoId);
        }


        public async Task<List<TodoItem>> GetTodoItemsAsync()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public void InsertTodoItem(TodoItem todo)
        {
            _context.TodoItems.Add(todo);
        }

        public async Task<TodoItem> InsertTodoItemAsync(TodoItem todoItem)
        {
             _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return todoItem;
        }


        public async Task<TodoItem> UpdateStudentAsync(TodoItem todoItem)
        {

            _context.Entry(todoItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return todoItem;
            
      
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool TodoItemExists(long todoId)
        {
            return _context.TodoItems.Any(e => e.TodoId == todoId);
        }
    }
}
