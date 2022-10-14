using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

using MongoDB.Driver;

using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Catalog.Settings;
using Catalog.Utilities;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoRepository repository;
        public UserInfoController(IUserInfoRepository repository) // had to add type to parameter
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<UserInfoDto>> GetUserInfoAsync()
        {
            IEnumerable<UserInfoDto> userInfo = null;
            try
            {
                userInfo = (await repository.GetUserInfoAsync()).Select(userInfo => userInfo.AsDto());
            } 
            catch (Exception ex) 
            {
                // nothing
            }
            
            return userInfo; // this was a circular definition, I also had to type cast it in order to get rid of the error
            // (IEnumerable<UserInfoController>) removed from line 24
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfoDto>> GetUserInfoAsync(Guid id)
        {
            var userInfo = await repository.GetUserInfoAsync(id);

            if (userInfo is null)
            {
                return NotFound();
            }

            return userInfo.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<UserInfoDto>> CreateUserInfoAsync(CreateUserInfoDto userInfoDto)
        {
            UserInfo userInfo = new()
            {
                Id = Guid.NewGuid(),
                Name = userInfoDto.Name,
                Dob = userInfoDto.Dob,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await repository.CreateUserInfoAsync(userInfo);

            return CreatedAtAction(nameof(GetUserInfoAsync), new{id = userInfo.Id}, userInfo.AsDto());
        }

        [HttpPut("{id}")] // must specify
        public async Task<ActionResult> UpdateUserInfoAsync(Guid id, UpdateUserInfoDto userInfoDto)
        {
            var existingUser = await repository.GetUserInfoAsync(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            UserInfo updatedUserInfo = existingUser with
            {
                Name = userInfoDto.Name,
                Dob = userInfoDto.Dob
            };

            await repository.UpdateUserInfoAsync(updatedUserInfo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserInfoAsync(Guid id)
        {
            var existingUser = await repository.GetUserInfoAsync(id);

            if (existingUser is null)
            {
                return NotFound();
            }

           await  repository.DeleteUserInfoAsync(id);

            return NoContent();
        }
    }
}