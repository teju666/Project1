namespace Project1.Models.Entities
{
    public class Project
    {
        public int Id { get; set; } //  We can also use GUID as well
        public required string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}