using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListServerApp.Models;
using TodoListServerApp.DAL;

namespace TodoListServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemsController(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            var todoItems =  await _todoItemRepository.GetTodoItemsAsync();
            if(todoItems == null)
            {
                return BadRequest();
            }
            return todoItems;

        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            //var todoItem = await _context.TodoItems.FindAsync(id);
            var todoItem = await _todoItemRepository.GetTodoItemByIdAsync(id);

            if (todoItem == null)
            {
                return NotFound(); 
            }

            return todoItem;
        }

        // PUT: api/TodoItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.TodoId)
            {
                return BadRequest();
            }

            try
            {
                await _todoItemRepository.UpdateStudentAsync(todoItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_todoItemRepository.TodoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            await _todoItemRepository.InsertTodoItemAsync(todoItem);
            return CreatedAtAction("GetTodoItem", new { id = todoItem.TodoId }, todoItem);
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(long id)
        {
            var todoItem = await _todoItemRepository.GetTodoItemByIdAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            return await _todoItemRepository.DeleteTodoItemAsync(todoItem);
        }

    }
}
