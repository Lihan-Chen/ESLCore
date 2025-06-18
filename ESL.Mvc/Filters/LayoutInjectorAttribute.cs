using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ESL.Mvc.Filters
{
    public class LayoutInjecterAttribute(string layoutName) : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var result = filterContext.Result as ViewResult;
            if (result != null)
            {
                result.ViewData["Layout"] = layoutName;
            }
        }
    }
}

// http://stackoverflow.com/questions/5161380/how-do-i-specify-different-layouts-in-the-asp-net-mvc-3-razor-viewstart-file
