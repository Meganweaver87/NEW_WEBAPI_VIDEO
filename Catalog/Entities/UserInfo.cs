using System.Linq;
using System.ComponentModel.DataAnnotations;

using Catalog.Controllers;
using Catalog.Dtos;
using Catalog.Repositories;

namespace Catalog.Entities
{
    public record UserInfo // had to restart omnisharp
    {
        public Guid Id {get; init;} 

        // [NotNull] // tbd
        public string? Name {get; init;} // the ? takes away the CS8618 message but idk if my type is getting set correctly
        public DateTime Dob {get; init;}
        public DateTimeOffset CreatedDate {get; init;}
    }
}