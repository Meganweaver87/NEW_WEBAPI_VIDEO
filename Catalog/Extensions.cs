using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
    
using Catalog.Controllers;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Catalog.Settings;
using Catalog.Utilities;

namespace Catalog
{
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