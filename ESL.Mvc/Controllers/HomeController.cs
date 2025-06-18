using ESL.Application.Interfaces.IServices;
using ESL.Infrastructure.DataAccess;
using Shift = ESL.Core.Models.Enums.Shift;
using OperatorType = ESL.Core.Models.Enums.OperatorType;
using Plant = ESL.Core.Models.Enums.Plant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Model.Strings;
using ESL.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using ESL.Core.Models.BusinessEntities;
using Microsoft.Identity.Web;

namespace ESL.Mvc.Controllers
{
    // https://github.com/Azure-Samples/active-directory-aspnetcore-webapp-openidconnect-v2/blob/master/5-WebApp-AuthZ/5-1-Roles/Controllers/HomeController.cs
    [AuthorizeForScopes(ScopeKeySection = "MicrosoftGraph:Scopes")]
    [Authorize]
    public class HomeController(EslDbContext context,
                                IHttpContextAccessor httpContextAccessor,
                                ILogger<HomeController> logger,
                                ICoreService coreService) : BaseController<HomeController>(context, httpContextAccessor, logger, coreService)
    {
        private readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<HomeController>? _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        private readonly ICoreService _CoreService = coreService ?? throw new ArgumentNullException(nameof(coreService));

        private string? _userID;
        private string? _userName;
        private int? _facilNo;
        private string? _facilName;
        private bool _showAlert = false;
        private Shift? _shift;
        private bool _isUserAuthenticatedOnly; // IsAuthenticatedOnly;
        private bool _isUserAnOperator = false;

        [Authorize]  // user must have been authenticated to access this action
        public IActionResult Index(string returnUrl, bool showAlert = false)
        {
            // get the username from the authenticated user  
            string? _userName = UserName;

            // look for user in the database using the username
            _userID = UserID; // SessionUser.EmployeeID

            // _isUserAnOperator is used as a flag to redirect the user to the SelectPlant action if they are not authenticated or not an operator
            _isUserAnOperator = IsOperator;
            
            // Check if the user has a valid session  
            var session = HttpContext.Session;
            
            try
            {               
                if (session != null && session.IsAvailable)
                {
                    // string sessionId = session.Id;
 
                    Guid _sessionGuid = Guid.Parse(session.Id);

                    // check if the session is new, i.e. it contains a UserSelectedPlant  
                    if (!IsSessionReady(SessionKeyUserSelectedPlant)) // "UserSelectedPlant"  
                    {
                        var userSession = new UserSession
                        {
                            SessionID = _sessionGuid, // Use the converted Guid  
                            UserName = _userName,
                            UserID = _userID,
                            IsUserAnOperator = _isUserAnOperator,
                            //Role = string.Empty // Default role, can be updated later  
                        };

                        // Clear the content of the session (not the session itself)
                        session.Clear();

                        // Set Session Values for UserSession
                        SetSessionValueAsync(SessionKeyUserSessionID, _sessionGuid.ToString());
                        SetSessionValueAsync(SessionKeyUserName, _userName ?? string.Empty);
                        SetSessionValueAsync(SessionKeyUserID, _userID ?? string.Empty);
                        SetSessionValueAsync(SessionKeyIsUserAnOperator, _isUserAnOperator.ToString());

                        // Guid savedSessionId = _CoreService.SaveUserSession(userSession).Result;
                        // Redirect to the SelectPlant action to set UserSession (UserID, UserName, isAuthenticatedOnly, role) if the session is not ready  

                        // ViewData["IsUserAnOperator"] = _isUserAnOperator; // Pass the flag to the view  
                        ViewData["UserSession"] = userSession; // Pass the username to the view  
                        ViewData["ShowAlert"] = showAlert; // Pass the showAlert flag to the view  
                        ViewData["ReturnUrl"] = returnUrl; // Pass the returnUrl to the view  

                        return RedirectToAction("SelectPlant", "Home");
                    }

                    var cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(7), // Cookie expires in 7 days
                        Path = "/", // Cookie is accessible from the root path
                        HttpOnly = true, // Cookie is not accessible by client-side scripts
                        Secure = true, // Cookie is only transmitted over HTTPS
                        SameSite = SameSiteMode.Strict // Restrict cookie to same-site requests
                    };

                    Response.Cookies.Append("AdvancedCookie", "someValue", cookieOptions);
                    // Additional logic here...  
                    return RedirectToAction("Index", "AllEvents");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions related to session management  
                Console.WriteLine($"Session error: {ex.Message}");

                session.Clear(); // Clear the session in case of an error

                // https://stackoverflow.com/questions/40217623/redirect-to-login-when-unauthorized-in-asp-net-core
                RedirectToAction(LoginUrl);
            }

            return View();
        }

        public IActionResult SelectPlant(string? returnUrl = null)
        {
            //// Get the session
            //_ = HttpContext.Session;

            //// Check if the session is ready
            //if (IsSessionReady(SessionKeyUserSelectedPlant)) // "UserSelectedPlant"
            //{
            //    // If the session is ready, redirect to the Index action
            //    return RedirectToAction("Index");
            //}

            // If not ready, prepare the view model or data for selecting a plant
            ViewData["ReturnUrl"] = returnUrl; // Pass the returnUrl to the view
            return View();
        }

        public bool IsSessionReady(string key)
        {
            // Get the session
            var session = HttpContext.Session;

            // Fix for CS1503: Convert the byte[] value to string after retrieving it
            if (session.TryGetValue(key, out byte[]? valueBytes))
            {
                return valueBytes is not null;
            }
            else
            {
                // Key doesn't exist, handle accordingly
                return valueBytes is null; // Or return a different result
            }
        }

        public void SetSessionValueAsync(string key, string value)
        {
            // Get the session
            var session = HttpContext.Session;

            // Convert the string value to byte[] for storage
            byte[] valueBytes = System.Text.Encoding.UTF8.GetBytes(value);

            // Set the session value
            session.Set(key, valueBytes);

            //return Task.CompletedTask;
        }

        public string GetSessionValueAsync(string key)
        {
            string value = string.Empty;

            // Get the session
            var session = HttpContext.Session;
            // Try to get the value from the session
            if (session.TryGetValue(key, out byte[]? valueBytes))
            {
                // Convert the byte[] back to string
                value = System.Text.Encoding.UTF8.GetString(valueBytes);
            }
            
            return value;
        }

        public Employee? GetEmployeeByEmployeeName(string? userName)
        {
            // Use _CoreService (instance of ICoreService) to fetch employee details
            return userName != null ? _CoreService.GetEmployeeByEmployeeName(userName).Result : null;
        }
    }
}
