using FakeAPI.Models;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Text;

namespace FakeAPI.Repository
{
    public class TodoRestRepository : ITodoRepository
    {
        string baseURL = "https://jsonplaceholder.typicode.com";
        HttpClient httpClient = new HttpClient();
        public TodoRestRepository()
        {
        }

        public List<Todo> GetAllTodo()
        {
            {
                var response = httpClient.GetAsync(baseURL + "/todos").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;

                    List<Todo> todos = JsonConvert.DeserializeObject<List<Todo>>(data);
                    return todos;
                }
                return null;
            }
        }

        public Todo GetTodoById(int id)
        {
            var response = httpClient.GetAsync(baseURL + "/todos/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                Todo todo = JsonConvert.DeserializeObject<Todo>(data);
                return todo;
            }
            return null;
        }

        public Todo AddTodo(Todo newTodo)
        {
            string data = JsonConvert.SerializeObject(newTodo);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = httpClient.PostAsync(baseURL + "/todos", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                Todo todo = JsonConvert.DeserializeObject<Todo>(responsecontent);
                return todo;
            }
            return null;
        }

        public Todo UpdateTodo(int id, Todo newTodo)
        {
            string data = JsonConvert.SerializeObject(newTodo);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync(baseURL + "/todos/" + id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                Todo todo = JsonConvert.DeserializeObject<Todo>(responsecontent);
                return todo;
            }
            return null;
        }

        public Todo DeleteTodo(int id)
        {
            var response = httpClient.DeleteAsync(baseURL + "/todos/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                Todo todo = JsonConvert.DeserializeObject<Todo>(data);
                return todo;
            }
            return null;
        }
    }
}
