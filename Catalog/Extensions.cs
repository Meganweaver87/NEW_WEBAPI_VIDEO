using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog
{
    using System.Linq;
    
    using Catalog.Controllers;
    using Catalog.Dtos;
    using Catalog.Entities;
    using Catalog.Repositories;
    
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
    } // class
} // namespace