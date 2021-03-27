using Microsoft.AspNetCore.Mvc;
using MyFavorRepos.Common;
using MyFavorRepos.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFavorRepos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MgFavorReposController : ControllerBase
    {
        private readonly ILeftService _iLeft = null;
        public MgFavorReposController(ILeftService left)
        {
            _iLeft = left;
        }
        [HttpGet]
        [Route("GetLeftList")]
        public string GetLeftList()
        {
            Log4NetUtil.LogInfo("test");
            return _iLeft.GetList();
        }
    }
}
