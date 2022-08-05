using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace RedisExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        readonly private IDatabase _database;
        public TimeController(IDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        public string Get()
        {
           return _database.StringGet("timeCache");
        }

        [HttpPost]
        public void Post()
        {
           _database.StringSet("timeCache",DateTime.Now.ToLongTimeString());
        }
    }
}
