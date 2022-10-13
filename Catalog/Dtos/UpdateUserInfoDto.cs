using System.ComponentModel.DataAnnotations;

using Catalog.Controllers;
using Catalog.Entities;
using Catalog.Repositories;
using Catalog.Utilities;

namespace Catalog.Dtos
{
    public record UpdateUserInfoDto
    {
        
        [Required]
        // [NotNull]
        public string? Name {get; init;}

        [Required]
        [CustomDate]  
        public DateTime Dob {get; init;}
        
    }
}