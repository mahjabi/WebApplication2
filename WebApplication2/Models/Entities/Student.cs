namespace WebApplication2.Models.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public int Capacity {  get; set; }
        public DateOnly Date { get; set; }
        public int Price {  get; set; }
        public string Visiting_Hour {  get; set; }
        public string Description { get; set; }


        public bool Subscribed { get; set; }
    }
}
