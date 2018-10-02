using SingleWebMvcCrud.Model;
using System.Collections.Generic;

namespace SingleWebMvcCrud.Services
{
    public class InMemoryTodosData : ITodosData
    {
        private readonly List<Todo> _todos;

        public InMemoryTodosData()
        {
            _todos = new List<Todo>() { };
        }

        public IEnumerable<Todo> GetAll()
        {
            return AssignId(_todos);
        }

        private IEnumerable<Todo> AssignId(List<Todo> todos)
        {
            foreach (var todo in todos)
            {
                var index = todos.IndexOf(todo) + 1;
                if (todo.Id != index)
                {
                    todo.Id = index;
                }
            }
            return todos;
        }

        public Todo GetById(int id)
        {
            return _todos.Find(t => t.Id == id);
        }

        public IEnumerable<Todo> AddOne(Todo todo)
        {
            _todos.Add(todo);
            return _todos;
        }

        public Todo Edit(int id, string whatIsToDo)
        {
            var todo = GetById(id);
            todo.WhatIsTodo = whatIsToDo;
            return todo;
        }

        public IEnumerable<Todo> DeleteOne(int id)
        {
            _todos.Remove(GetById(id));
            return _todos;
        }
    }
}
