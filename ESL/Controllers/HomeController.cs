using ESL.Core.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Web;
using System.Diagnostics;

namespace ESL.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly GraphServiceClient _graphServiceClient;
        private readonly ILogger<HomeController> _logger;
        //private readonly IEmployeeRepository _employees;
        private readonly IAllEventRepository _allEvents;

        public HomeController(ILogger<HomeController> logger, GraphServiceClient graphServiceClient, IAllEventRepository allEvents) 
        {
            _logger = logger;
            _graphServiceClient = graphServiceClient;
            _allEvents = allEvents;
        }

        [AuthorizeForScopes(ScopeKeySection = "MicrosoftGraph:Scopes")]
        public async Task<IActionResult> Index()
        {
            // From ClaimsPrincipal in base controller
            string userName = User.Identity!.AuthenticationType + User.Identity!.Name;

            bool isUserAuthenticated = User.Identity.IsAuthenticated;
            //
            // user is from Microsoft Graph which contains GivenName, Surname, Id (Guid), DisplayName, OfficeLocation, BusinessPhones, MobilePhone, JobTitle, ODataType (Mocrosoft.Graphu.User), Mail, UserPrincipalName (=email)
            var user = await _graphServiceClient.Me.Request().GetAsync();

            // var users = await _graphServiceClient.Users.Request().GetAsync().ConfigureAwait(false);

            //Employee? employee = await _employees.GetEmployee(user.GivenName, user.Surname)!;

            //UserInfo? userInfo = new UserInfo() { EmployeeNo = employee.EmployeeNo, LastName = employee.LastName, FirstName = employee.LastName, PrincipalName = user.UserPrincipalName };

            //UserInfo userInfo = new(employee.EmployeeNo, user.Surname, user.GivenName, user.UserPrincipalName);

            ViewData["GraphApiResult"] = $"The user {userName} has been authenticated. From Microsoft Graph: User Given Name: {user.GivenName}, Surname: {user.Surname}{Environment.NewLine}DisplayName: {user.DisplayName}, UserPrincipalName: {user.UserPrincipalName}"; // {userInfo.EmployeeNo}

            try
            {
                var currentEvents = _allEvents.GetAll(6); // .GetDefaultAllEventsByFacil(facilNo, startDate, endDate);

                return View(currentEvents);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
