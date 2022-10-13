using System.Linq;

using Catalog.Controllers;
using Catalog.Entities;
using Catalog.Repositories;


namespace Catalog.Dtos{
     public record UserInfoDto
    {
        public Guid Id {get; init;} 
        public string? Name {get; init;}
        public DateTime Dob {get; init;}
        public DateTimeOffset CreatedDate {get; init;}
    }
}