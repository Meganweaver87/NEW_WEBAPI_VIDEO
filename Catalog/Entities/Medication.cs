// using System.Linq;
// using System.ComponentModel.DataAnnotations;

// using Catalog.Controllers;
// using Catalog.Dtos;
// using Catalog.Repositories;

// namespace Catalog.Entities
// {
//     public record Medication
//     {
//         public Guid Id {get; init;}

//         // [NotNull]
//         public string? Name {get; init;} // took out ? because we can use NotNull attribute
//         public DateTime PassTime {get; set;}
//         public double Strength {get; set;}
//         public double Quantity {get; set;}
//         public DateTimeOffset CreatedDate {get; init;}

//     }
// }