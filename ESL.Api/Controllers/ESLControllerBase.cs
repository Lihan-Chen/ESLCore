using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ESL.Api.Controllers
{
    public class ESLControllerBase : Controller
    {
        public ESLControllerBase()
        {
            
        }
        public static int sessionFacilNo = 1;
       
    }
}
