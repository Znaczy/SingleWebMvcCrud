using Microsoft.AspNetCore.Mvc;
using SingleWebMvcCrud.Model;
using SingleWebMvcCrud.Services;
using System.Collections.Generic;

namespace SingleWebMvcCrud.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private ITodosData _todos;

        public TodosController(ITodosData todos)
        {
            _todos = todos;
        }

        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return _todos.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Todo> Get(int id)
        {
            return _todos.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Todo todo)
        {
            if (ModelState.IsValid)
            {
                _todos.AddOne(todo);
            }
            return new ObjectResult("Todo added");
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Todo todo)
        {
            _todos.Edit(todo.Id, todo.WhatIsTodo);
            return new ObjectResult("Todo updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _todos.DeleteOne(id);
            return new ObjectResult("Todo removed");
        }
    }
}
