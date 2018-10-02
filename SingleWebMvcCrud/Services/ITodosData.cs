using SingleWebMvcCrud.Model;
using System.Collections.Generic;

namespace SingleWebMvcCrud.Services
{
    public interface ITodosData
    {
        IEnumerable<Todo> GetAll();
        Todo GetById(int id);
        IEnumerable<Todo> AddOne(Todo todo);
        Todo Edit(int id, string whatIsToDo);
        IEnumerable<Todo> DeleteOne(int id);
    }
}
