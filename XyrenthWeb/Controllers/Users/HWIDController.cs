using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using XyrenthWeb.Database;
using XyrenthWeb.Models;
using XyrenthWeb.Services;

namespace XyrenthWeb.Controllers
{
    [ApiController]
    [Route("users/[controller]")]
    public class HWIDController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;
        private readonly Query query;

        public HWIDController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
            query = _databaseService.GetQuery();
        }

        [HttpGet]
        public IEnumerable<HWIDModel> Get()
        {
            HWIDModel.LoadFromQuery(query.ExecProcedure("GetAllHWIDs"));
            return HWIDModel.All;
        }
    }
}
