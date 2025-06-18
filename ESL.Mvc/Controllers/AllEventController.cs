using ESL.Application.Interfaces.IServices;
using ESL.Infrastructure.DataAccess;
using ESL.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Graph;

namespace ESL.Mvc.Controllers
{
    public class AllEventController(EslDbContext context,
                                    IHttpContextAccessor httpContextAccessor,
                                    ILogger<AllEventController> logger,
                                    ICoreService coreService,
                                    IAllEventService allEventService) : BaseController<AllEventController>(context, httpContextAccessor, logger, coreService)
    {
        private readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private ILogger<AllEventController>? _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private IHttpContextAccessor _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        private ICoreService _employeeService = coreService ?? throw new ArgumentNullException(nameof(coreService));
        private IAllEventService _allEventService = allEventService ?? throw new ArgumentNullException(nameof(allEventService));

        int? _facilNo;
        int? _logTypeNo;
        string? _eventID; // = string.Empty;
        int? _eventID_RevNo;
        string? _facilName;
        string? _logTypeName;
        string? _startDate;
        string? _endDate;
        DateTime? initialStartDate;
        // _operatorType values: ["Primary", "Secondary"] this corresponds to database table value
        string _operatorType = String.Empty;
        // _opType values: [true, false] this corresponds to web page checkbox values (true = Primary, false = Secondary)
        bool _opType = true;

        public IActionResult Index(LogFilterPartialViewModel? logFilterPartial, int? facilNo, DateOnly? startDate, DateOnly? endDate, string? searchString, bool? operatorType, int? page)
        {
            // logFilterPartial may be null
            // so use logFilterPartial last

            // Set up default values
            // Default to tomorrow if the model EndDate or endDate is null
            DateOnly _enDt = endDate ?? (logFilterPartial?.EndDate.HasValue == true ? logFilterPartial.EndDate.Value : Tomorrow);

            DateOnly _stDt = startDate ?? (logFilterPartial?.StartDate.HasValue == true ? logFilterPartial.StartDate.Value : _enDt.AddDays(DaysOffSet));

            if (_stDt > _enDt) { return BadRequest($"Start Date {_stDt} must not be later than End Date {_enDt}."); }

            HttpContext.Session.SetString(SessionKeyUserSessionStart, _stDt.ToString("yyyyMMdd")); //"MM/dd/yyyy"
            HttpContext.Session.SetString(SessionKeyUserSessionEnd, _enDt.ToString("yyyyMMdd")); //"MM/dd/yyyy"

            // Facility
            _facilNo = facilNo ?? logFilterPartial?.FacilNo ?? FacilNo;

            _facilName = _employeeService.GetFacility(_facilNo!)?.Result?.FacilName;

            // _shiftNo
            int? shiftNoNullable = HttpContext.Session.GetInt32(key: SessionKeyUserShiftNo);
            if (shiftNoNullable.HasValue)
            {
                int _shiftNo = shiftNoNullable.Value;
                // Use _shiftNo as needed
            }
            else
            {
                // Handle the case where the session value is null
                int _shiftNo = Convert.ToInt32(GetDefaultShift());
            }

            searchString = !String.IsNullOrEmpty(logFilterPartial?.CurrentFilter) ? logFilterPartial.CurrentFilter : searchString;

            _opType = (bool)(operatorType.HasValue ? operatorType : (logFilterPartial?.OperatorType ?? _opType));

            var facilTypeList = _employeeService.GetFacilTypeList().Result;

            var logTypeList = _employeeService.GetLogTypeList().Result;

            var facilAbbrSelectList = new SelectList(facilTypeList, "Value", "Text", _facilNo);
            var logTypeSelectList = new SelectList(facilTypeList, "Value", "Text"); ;
            

            //_logFilterPartial is a new record which  may be different from the logFilterPartial record

            LogFilterPartialViewModel _logFilterPartial = new LogFilterPartialViewModel()
            {
                FacilNo = _facilNo,
                LogTypeNo = _logTypeNo,
                StartDate = _stDt,
                EndDate = _enDt,
                OperatorType = _opType,
                CurrentFilter = searchString,
                FacilNos = facilAbbrSelectList, //new SelectList(facilAbbrList, "Value", "Text", _facilNo),
                LogTypeNos = logTypeSelectList
            };

            var viewmodel = new AllEventOutstandingViewModel()
            {
                LogFilterPartial = _logFilterPartial
            };

            return View();
        }
    }
}
