// using Microsoft.AspNetCore.Mvc;
// using System.Linq;

// using Catalog.Dtos;
// using Catalog.Entities;
// using Catalog.Repositories;

// namespace Catalog.Controllers
// {
//     [ApiController]
//     [Route("medication")]
//     public class MedicationController : ControllerBase
//     {
//         private readonly IMedicationRepository repository;
//         public MedicationController(IMedicationRepository repository) // had to add type to parameter
//         {
//             this.repository = repository;
//         }

//         [HttpGet]
//         public IEnumerable<MedicationDto> GetMedication()
//         {
//             IEnumerable<MedicatonDto> med = null;
//             try
//             {
//                 med = repository.GetMedicaton().Select(med => med.AsDto());
//             } 
//             catch (Exception ex) 
//             {
//                 // nothing
//             }
            
//             return med; // this was a circular definition, I also had to type cast it in order to get rid of the error
//             // (IEnumerable<UserInfoController>) removed from line 24
//         }

//         [HttpGet("{id}")]
//         public ActionResult<MedicationDto> GetMedication(Guid id)
//         {
//             var med = repository.GetMedication(id);

//             if (med is null)
//             {
//                 return NotFound();
//             }

//             return med.AsDto();
//         }

//         [HttpPost]
//         public ActionResult<MedicationDto> CreateMedication(CreateMedicationDto MedicationDto)
//         {
//             Medication med = new()
//             {
//                 Id = Guid.NewGuid(), // should be user id
//                 Name = medDto.Name,
//                 PassTime = medDto.PassTime,
//                 Quantity = medDto.Quantity,
//                 Strength = medDto.Strength,
//                 CreatedDate = DateTimeOffset.UtcNow
//             };

//             repository.CreateMedication(med);

//             return CreatedAtAction(nameof(GetMedication), new{id = med.Id}, med.AsDto());
//         }

//         [HttpPut("{id}")] // must specify
//         public ActionResult UpdateMedication(Guid id, UpdateMedicationDto medDto)
//         {
//             var existingUser = repository.GetMedication(id);

//             if (existingUser is null)
//             {
//                 return NotFound();
//             }

//             Medication updatedMedication = existingUser with
//             {
//                 Name = medDto.Name,
//                 PassTime = medDto.PassTime,
//                 Quantity = medDto.Quantity,
//                 Strength = medDto.Strength
//             };

//             repository.UpdateMedication(updatedMedication);

//             return NoContent();
//         }

//         [HttpDelete("{id}")]
//         public ActionResult DeleteMedication(Guid id) // how do i delete a specific med if they have the same user Id? Will need a med id
//         {
//             var existingUser = repository.GetMedication(id);

//             if (existingUser is null)
//             {
//                 return NotFound();
//             }

//             repository.DeleteMedication(id);

//             return NoContent();
//         }
//     }
// }