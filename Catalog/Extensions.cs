using MongoDB.Driver;

using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog
{
    using System.Linq;
    
    using Catalog.Controllers;
    using Catalog.Dtos;
    using Catalog.Entities;
    using Catalog.Repositories;
    using Catalog.Settings;
    using Catalog.Utilities;
    
    public static class Extensions{ // also had to restart omnisharp here
        public static UserInfoDto AsDto(this UserInfo userInfo)
        {
            return new UserInfoDto
            {
                Id = userInfo.Id,
                Name = userInfo.Name,
                Dob = userInfo.Dob,
                CreatedDate = userInfo.CreatedDate
            };
        }

        // public static MedicationDto AsDto(this Medication med)
        // {
        //     return new MedicationDto
        //     {
        //         Id = userInfo.Id, // should be user id?
        //         Name = Medication.Name,
        //         PassTime = Medication.PassTime,
        //         Quantity = Medication.Quantity,
        //         Strength = Medication.Strength,
        //         CreatedDate = userInfo.CreatedDate
        //     };
        // }
    } // class
} // namespace