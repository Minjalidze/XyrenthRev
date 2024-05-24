using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using XyrenthWeb.Database;
using XyrenthWeb.Models;
using XyrenthWeb.Services;

namespace XyrenthWeb.Controllers
{
    [ApiController]
    [Route("users/[controller]")]
    public class TotalitarizmController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;
        private readonly Query query;

        public TotalitarizmController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
            query = _databaseService.GetQuery();
        }

        [HttpGet]
        public IEnumerable<TotalitarizmModel> Get()
        {
            TotalitarizmModel.LoadFromQuery(query.ExecSql("SELECT * FROM totalitarizm"));
            return TotalitarizmModel.All;
        }
    }
}
