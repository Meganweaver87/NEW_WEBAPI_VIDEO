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
    }
}