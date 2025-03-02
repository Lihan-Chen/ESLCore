using ESL.Core.Data;
using ESL.Core.Models.Enums;
using ESL.Mvc.Services;
using ESL.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ESL.Mvc.Controllers
{
    public class AllEventController : BaseController<AllEventController>
    {
        private readonly EslDbContext _context;
        private ILogger<AllEventController>? _logger;
        private readonly IEmployeeService _employeeService;
        private IAllEventService _allEventService;

        public AllEventController(EslDbContext context, ILogger<AllEventController> logger, IEmployeeService employeeService, IAllEventService allEventService) : base(context, logger, employeeService)
        {
            _context = context;
            _logger = logger;
            _employeeService = employeeService;
            _allEventService = allEventService;
        }

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

            //
            if (startDate > endDate) { return BadRequest("Start Date cannot be after End Date"); }
            
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

            // Set up default values
            // Default to tomorrow if the model EndDate or endDate is null
            DateOnly? _enDt = endDate ?? (logFilterPartial?.EndDate.HasValue == true ? logFilterPartial.EndDate.Value :  Tomorrow);

            DateOnly? _stDt = startDate ?? (logFilterPartial?.StartDate.HasValue == true ? logFilterPartial.StartDate.Value : _enDt?.AddDays(DaysOffSet));
            
            HttpContext.Session.SetString(SessionKeyUserSessionStartDate, _stDt.Value.ToString("yyyyMMdd")); //"MM/dd/yyyy"
            HttpContext.Session.SetString(SessionKeyUserSessionEndDate, _enDt.Value.ToString("yyyyMMdd")); //"MM/dd/yyyy"

            searchString = !String.IsNullOrEmpty(logFilterPartial?.CurrentFilter) ? logFilterPartial.CurrentFilter : searchString;

            _opType = (bool)(operatorType.HasValue ? operatorType : (logFilterPartial?.OperatorType ?? _opType));

            var facilAbbrSelectList = _employeeService.GetPlantSelectList(_facilNo).Result;
            var logTypeSelectList = _employeeService.GetLogTypeSelectList(_logTypeNo).Result;
            

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
