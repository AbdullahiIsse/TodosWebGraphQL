using System.Threading.Tasks;
using HotChocolate;
using TodosWebGraphQL.Data;
using TodosWebGraphQL.GraphQL.Todos;
using TodosWebGraphQL.Models;

namespace TodosWebGraphQL.GraphQL
{
    public class Mutation
    {

        public async Task<AddtodoPayload> AddTodoAsync(AddTodosInput input, [Service] ITodoData context)
        {

            var todo = new Todo
            {
                Title = input.Title
            };

            await context.AddTodo(todo);

            return new AddtodoPayload(todo);

        }



    }
}