namespace RequestsToServer.Models
{
    public class Employee : Validation
    {
        public string Name { get; set; } = null!;

        public string Job { get; set; } = null!;

        public string? Id { get; set; }

        public string CreatedAt { get; set; } = null!;

        public string? UpdatedAt { get; set; }
    }
}