namespace FakeAPI.Models
{
    public class Todo
    {
        public int userId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Completed { get; set; }

        public Todo() { }

        public Todo(int userId, int id, string title, string completed)
        {
            this.userId = userId;
            Id = id;
            Title = title;
            Completed = completed;
        }
    }
}