using System.Linq;
using System.ComponentModel.DataAnnotations;

using MongoDB.Driver;

using Catalog.Controllers;
using Catalog.Entities;
using Catalog.Repositories;
using Catalog.Settings;
using Catalog.Utilities;


namespace Catalog.Dtos{
     public record UserInfoDto
    {
        public Guid Id {get; init;} 
        
        // [NotNull]
        public string? Name {get; init;}
        public DateTime Dob {get; init;}
        public DateTimeOffset CreatedDate {get; init;}
    }
}