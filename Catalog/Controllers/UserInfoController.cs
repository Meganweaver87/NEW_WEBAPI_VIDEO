using Microsoft.AspNetCore.Mvc;
using System.Linq;

using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("userinfo")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoRepository repository;
        public UserInfoController(IUserInfoRepository repository) // had to add type to parameter
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<UserInfoDto> GetUserInfo()
        {
            IEnumerable<UserInfoDto> userInfo = null;
            try
            {
                userInfo = repository.GetUserInfo().Select(userInfo => userInfo.AsDto());
            } 
            catch (Exception ex) 
            {
                // nothing
            }
            
            return userInfo; // this was a circular definition, I also had to type cast it in order to get rid of the error
            // (IEnumerable<UserInfoController>) removed from line 24
        }

        [HttpGet("{id}")]
        public ActionResult<UserInfoDto> GetUserInfo(Guid id)
        {
            var userInfo = repository.GetUserInfo(id);

            if (userInfo is null)
            {
                return NotFound();
            }

            return userInfo.AsDto();
        }

        [HttpPost]
        public ActionResult<UserInfoDto> CreateUserInfo(CreateUserInfoDto userInfoDto)
        {
            UserInfo userInfo = new()
            {
                Id = Guid.NewGuid(),
                Name = userInfoDto.Name,
                Dob = userInfoDto.Dob,
                CreatedDate = DateTimeOffset.UtcNow
            };

            repository.CreateUserInfo(userInfo);

            return CreatedAtAction(nameof(GetUserInfo), new{id = userInfo.Id}, userInfo.AsDto());
        }

        [HttpPut("{id}")] // must specify
        public ActionResult UpdateUserInfo(Guid id, UpdateUserInfoDto userInfoDto)
        {
            var existingUser = repository.GetUserInfo(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            UserInfo updatedUserInfo = existingUser with
            {
                Name = userInfoDto.Name,
                Dob = userInfoDto.Dob
            };

            repository.UpdateUserInfo(updatedUserInfo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUserInfo(Guid id)
        {
            var existingUser = repository.GetUserInfo(id);

            if (existingUser is null)
            {
                return NotFound();
            }

            repository.DeleteUserInfo(id);

            return NoContent();
        }
    }
}