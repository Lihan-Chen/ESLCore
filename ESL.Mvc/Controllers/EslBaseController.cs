using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ESL.Infrastructure.DataAccess;
using ESL.Mvc.Controllers;
using ESL.Core.Models.Enums;
using ESL.Mvc.ViewModels;
using ESL.Core.Models.BusinessEntities;

public abstract class EslBaseController(EslDbContext context, IHttpContextAccessor httpContextAccessor) : Controller
{
    protected readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));

    protected readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    public bool IsAuthenticated => User.Identity!.IsAuthenticated;

    public static string UserSessionID; // => _httpContextAccessor.HttpContext.Session.Id;

    // Find username (LastName,FirstName) to get the User object from Oracle DbContext
    public string? UserName => User.Identity!.IsAuthenticated ? User.FindFirst(c => c.Type == "name")?.Value : string.Empty;

    // SessionUser is the authenticated user that should have been recorded in the ESL_Employee table from Oracle ESL schema
    public static Employee? SessionUser { get; set; } // set by HomeController
    public static int? UserEmployeeNo => SessionUser?.EmployeeNo;
    public static string? UserID => SessionUser?.EmployeeID;

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // First check if database is available
        if (_context == null || !_context.Database.CanConnect())
        {
            throw new InvalidOperationException("Database context is not available");
        }

        if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null)
        {
            throw new InvalidOperationException("HTTP context accessor is not available");
        }

        // Skip redirect for OnDuty controller to avoid infinite loops
        if (context.Controller is OnDutyController)
        {
            base.OnActionExecuting(context);
            return;
        }

        // Check if user is authenticated
        if (!User.Identity?.IsAuthenticated ?? false)
        {
            base.OnActionExecuting(context);
            return;
        }

        // Check for required session values
        var session = _httpContextAccessor.HttpContext?.Session;
        if (session != null)
        {
            var hasPlantId = session.GetInt32("PlantId").HasValue;
            var hasShift = !string.IsNullOrEmpty(session.GetString("Shift"));
            var hasOperatorType = !string.IsNullOrEmpty(session.GetString("OperatorType"));

            if (!hasPlantId || !hasShift || !hasOperatorType)
            {
                // Store the current URL to return after OnDuty selection
                session.SetString("ReturnUrl",
                    _httpContextAccessor.HttpContext?.Request.Path.Value ?? "/");

                // Redirect to OnDuty/Index
                context.Result = new RedirectToActionResult(
                    "Index", "OnDuty", null);
                return;
            }
        }

        base.OnActionExecuting(context);
    }

    public IActionResult RedirectToAction(string actionName, string controllerName, object? routeValues = null)
    {
        return new RedirectToActionResult(actionName, controllerName, routeValues);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        // Code to run after the action method is executed
        base.OnActionExecuted(context);
    }

    protected void SaveToSession(OnDutyViewModel model)
    {
        var session = _httpContextAccessor.HttpContext?.Session;
        if (session == null) return;

        // Save primary session data
        session.SetInt32("EmployeeNo", model.EmployeeNo);
        session.SetString("UserName", model.UserName ?? string.Empty);
        session.SetString("UserRole", model.UserRole ?? "Operator");

        // Fix for CS8604: Ensure SelectedShift is not null before calling ToString()
        session.SetString("Shift", model.SelectedShift?.ToString() ?? string.Empty);

        // Fix for CS8604: Ensure SelectedOperatorType is not null before calling ToString()
        session.SetString("OperatorType", model.SelectedOperatorType?.ToString() ?? string.Empty);

        // Save plant related data
        if (model.SelectedPlantId > 0) // Fix: Removed HasValue check since SelectedPlantId is an int, not nullable
        {
            session.SetInt32("PlantId", model.SelectedPlantId);
            session.SetString("PlantName", PlantHelper.GetPlantName(model.SelectedPlantId));
        }

        // Save timestamp for session tracking
        session.SetString("SessionStartTime", DateTime.Now.ToString("o"));
    }
}
