using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<UserInfoController> GetUserInfo()
        {
            var userInfo = (IEnumerable<UserInfoController>) repository.GetUserInfo();
            return userInfo; // this was a circular definition, I also had to type cast it in order to get rid of the error
        }

        [HttpGet("{id}")]
        public ActionResult<UserInfo> GetUserInfo(Guid id)
        {
            var userInfo = repository.GetUserInfo(id);
            if (userInfo is null)
            {
                return NotFound();
            }
            return userInfo;
        }
    }
}