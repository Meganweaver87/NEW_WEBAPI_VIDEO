// using Microsoft.AspNetCore.Mvc;
// using System.Linq;
// using System.Threading.Tasks;

// using MongoDB.Driver;

// using Catalog.Dtos;
// using Catalog.Entities;
// using Catalog.Repositories;
// using Catalog.Settings;
// using Catalog.Utilities;

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
//         public IEnumerable<MedicationDto> GetMedicationAsync()
//         {
//             IEnumerable<MedicatonDto> med = null;
//             try
//             {
//                 med = await repository.GetMedicationAsync().Select(med => med.AsDto());
//             } 
//             catch (Exception ex) 
//             {
//                 // nothing
//             }
            
//             return med; // this was a circular definition, I also had to type cast it in order to get rid of the error
//             // (IEnumerable<UserInfoController>) removed from line 24
//         }

//         [HttpGet("{id}")]
//         public Task<ActionResult<MedicationDto>> GetMedicationAsync(Guid id)
//         {
//             var med = await repository.GetMedication(id);

//             if (med is null)
//             {
//                 return NotFound();
//             }

//             return med.AsDto();
//         }

//         [HttpPost]
//         public Task<ActionResult<MedicationDto>> CreateMedicationAsync(CreateMedicationDto MedicationDto)
//         {
//             Medication med = new()
//             {
//                 UserId = UserInfo.Id,
//                 MedId = Guid.NewGuid(),
//                 Name = medDto.Name,
//                 PassTime = medDto.PassTime,
//                 Quantity = medDto.Quantity,
//                 Strength = medDto.Strength,
//                 CreatedDate = DateTimeOffset.UtcNow
//             };

//             await repository.CreateMedicationAsync(med);

//             return CreatedAtAction(nameof(GetMedication), new{id = med.Id}, med.AsDto());
//         }

//         [HttpPut("{id}")] // must specify
//         public async Task<ActionResult> UpdateMedicationAsync(Guid id, UpdateMedicationDto medDto)
//         {
//             var existingUser = await repository.GetMedicationAsync(id);

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

//             await repository.UpdateMedicationAsync(updatedMedication);

//             return NoContent();
//         }

//         [HttpDelete("{id}")]
//         public async Task<ctionResult> DeleteMedicationAsync(Guid id) // how do i delete a specific med if they have the same user Id? Will need a med id
//         {
//             var existingUser = await repository.GetMedicationAsync(id);

//             if (existingUser is null)
//             {
//                 return NotFound();
//             }

//             await repository.DeleteMedication(id);

//             return NoContent();
//         }
//     }
// }