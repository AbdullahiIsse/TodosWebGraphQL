using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;
using TodosWebGraphQL.Data;
using TodosWebGraphQL.Models;

namespace TodosWebGraphQL.GraphQL
{
    public class Mutation
    {

        public async Task<Todo> AddTodoAsync([Service]ITopicEventSender eventSender, [Service] ITodoData context,int userid,string title)
        {

            var todo = new Todo
            {
                Title = title,
                UserId = userid
            };

            var createdTodo = await context.AddTodo(todo);

            await eventSender.SendAsync("TodoCreated", createdTodo);

            return createdTodo;

        }
        
        
        public async Task<int> DeleteTodoAsync([Service]ITopicEventSender eventSender, [Service] ITodoData context,int id)
        {
            var removeTodo = context.RemoveTodo(id);
            
            await eventSender.SendAsync("RemoveTodo", removeTodo);

            return removeTodo;


        }
        
        
        public async Task<Todo> UpdateTodoAsync([Service]ITopicEventSender eventSender, [Service] ITodoData context,int userid,string title,int id)
        {
            var todo = context.Get(id);

            todo.Title = title;
            todo.UserId = userid;
            
            var updatedTodo = await context.Update(todo);

            await eventSender.SendAsync("TodoCreated", updatedTodo);

            return updatedTodo;

        }



    }
}