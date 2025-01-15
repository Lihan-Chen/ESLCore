using ESL.Mvc.Controllers;
using ESL.Mvc.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;

namespace ESL.Mvc.Area.Admin.Controllers
{
    public class AdminBaseController : BaseController
    {
        public string forceUpdate = "Y";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminBaseController(IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor) //, IDownstreamApi downstreamApi
        {
            this._httpContextAccessor = httpContextAccessor;
        }
    }
}
