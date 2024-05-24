using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XyrenthWeb.Database;
using XyrenthWeb.Models;
using XyrenthWeb.Services;

namespace XyrenthWeb.Controllers.Users
{
    [ApiController]
    [Route("users/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;
        private readonly Query query;

        public UserController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
            query = _databaseService.GetQuery();
        }

        [HttpGet]
        public IEnumerable<UserModel> Get()
        {
            UserModel.LoadFromQuery(query.ExecProcedure("GetAllUsers"));
            return UserModel.All;
        }
    }
}
