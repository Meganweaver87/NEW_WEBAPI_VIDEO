namespace Catalog.Entities
{
    public record UserInfo // had to restart omnisharp
    {
        public Guid Id {get; init;} 
        public string Name {get; init;}
        public DateTime Dob {get; init;}
        public DateTimeOffset CreatedDate {get; init;}
    }
}