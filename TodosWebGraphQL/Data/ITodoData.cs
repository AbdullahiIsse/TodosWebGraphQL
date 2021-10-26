using System.Collections.Generic;
using System.Threading.Tasks;
using TodosWebGraphQL.Models;

namespace TodosWebGraphQL.Data
{
    public interface ITodoData
    {


        IList<Todo> GetTodos();
        Task<Todo> AddTodo(Todo todo);
        void RemoveTodo(int todoId);

        Todo Update(Todo todo);

        Todo Get(int id);






    }
}