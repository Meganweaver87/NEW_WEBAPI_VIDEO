using System.ComponentModel.DataAnnotations;

using MongoDB.Driver;

using Catalog.Controllers;
using Catalog.Entities;
using Catalog.Repositories;
using Catalog.Utilities;
using Catalog.Settings;

namespace Catalog.Dtos
{
    public record CreateUserInfoDto
    {
        
       // [Required]
        // [NotNull]
        public string? Name {get; init;}

       // [Required]
        [CustomDate]  
        public DateTime Dob {get; init;}
        
    }
}