using Microsoft.EntityFrameworkCore;
using ESL.Core.IRepositories;
using System.Linq.Expressions;
using ESL.Core.Models.BusinessEntities;
using System.Globalization;
using ESL.Mvc.DataAccess.Persistence;

namespace ESL.Mvc.DataAccess.Repositories
{
    public class AllEventRepository : IAllEventRepository
    {
        protected EslDbContext _context;

        protected DbSet<AllEvent> _dbSet;

        protected DbSet<AllEventCurrent> _dbSetCurrent;

        protected readonly ILogger<AllEventRepository> _logger;

        public AllEventRepository(
            EslDbContext context, ILogger<AllEventRepository> logger)
        {
            _context = context;
            _dbSet = context.AllEvents;
            _dbSetCurrent = context.AllEventsCurrent;
            _logger = logger;
        }

        public IQueryable<AllEventCurrent> GetAllEventsCurrentQuery(int FacilNo)
        {
            return _dbSetCurrent.Where(x => x.FacilNo == FacilNo).AsNoTracking();

            //if (allEvents.Any())
            //{
            //    return allEvents;
            //}

            //return allEvents;
        }

        public IQueryable<AllEvent> GetDefaultAllEventsByFacil(int FacilNo, DateTime startDate, DateTime endDate)
        {
            return _dbSet.Where(x => x.FacilNo == FacilNo & x.EventDate >= startDate & x.EventDate <= endDate).AsNoTracking();
        }

        public IQueryable<AllEvent> GetByEvent(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo) //, AllEvent? allEvent
        {
            return _dbSet.Where(x => x.FacilNo == FacilNo & x.LogTypeNo == LogTypeNo & x.EventID == EventID & x.EventID_RevNo == EventID_RevNo);

            //if (allEvent == null) return null;

            //return allEvent;
        }

        // refer to the Reference region below
        public IQueryable<AllEvent> FindEvents(Expression<Func<AllEvent, bool>> predicate) => _dbSet.AsNoTracking().Where(predicate);

        // TODO: consider using value objects for start-end daterange to capture business logic
        // ESL.ESL_AllEvents_Active_Proc
        public IQueryable<AllEventCurrent> GetListQuery(int? facilNo, int? logTypeNo, string strStartDate, string strEndDate, string strSearch, string strOperatorType) // DateTime? startDate, DateTime? endDate, string? searchString, string? alert, int? page, bool? operatorType = false
        {
            DateTime _startDate;
            DateTime _endDate;
            string _dateFormat = "MM/dd/yyyy";
            CultureInfo provider = CultureInfo.InvariantCulture;

            var query = _dbSetCurrent
                   .AsNoTracking()
                   .TagWith("GetListQuery");

            bool isValidStartDate = DateTime.TryParseExact(strStartDate, _dateFormat, provider, DateTimeStyles.None, out _startDate);
            bool isValidEndDate = DateTime.TryParseExact(strEndDate, _dateFormat, provider, DateTimeStyles.None, out _endDate);


            if (isValidStartDate && isValidEndDate && _endDate >= _startDate)
            {
                query = query.Where(a => a.EventDate >= _startDate && a.EventDate <= _endDate);
            }

            if (facilNo.HasValue && logTypeNo.HasValue && !string.IsNullOrWhiteSpace(strOperatorType))
            {

                query = query.Where(a => a.FacilNo == facilNo &&
                               a.LogTypeNo == logTypeNo &&
                               a.OperatorType == strOperatorType);
            }

            return query.OrderByDescending(e => e.EventDate).ThenByDescending(u => u.UpdateDate);
        }

        public IQueryable<AllEventCurrent> GetItemQuery(int? facilNo, int? logTypeNo, string eventID, int? eventID_RevNo)
        {
            return _dbSetCurrent
                   .AsNoTracking()
                   .TagWith("GetItemQuery")
                   .Where(a => a.FacilNo == facilNo &&
                          a.LogTypeNo == logTypeNo &&
                          a.EventID == eventID &&
                          a.EventID_RevNo == eventID_RevNo);
        }

        public IQueryable<AllEvent> GetReportQuery(int? facilNo, int? logTypeNo, string strStartDate, string strEndDate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<AllEventRelatedTo> GetSearch_RelatedToListQuery(int FacilNo, int LogTypeNo, string strStartDate, string strEndDate, string strOperatorType, string optionAll, string searchValues)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Details> GetDetailsListQuery(int facilNo)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Subject> GetSubjectListQuery(int facilNo)
        {
            throw new NotImplementedException();
        }

        #region private method

        private DateTime To_Date(string strDate, string? strFormat)
        {
            if (strDate == null) return DateTime.MinValue;

            DateTime _date;

            CultureInfo provider = CultureInfo.InvariantCulture;

            bool success = DateTime.TryParseExact(strDate, strFormat, provider, DateTimeStyles.None, out _date);

            return _date;
        }

        #endregion

        //public async AllEvent? GetAllEvent(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo)
        //{
        //    return await dbSet.FirstOrDefaultAsync(x => x.FacilNo == FacilNo & x.LogTypeNo == LogTypeNo & x.EventID == EventID & x.EventID_RevNo == EventID_RevNo);
        //}

        //public async Task<bool> AddAsync(AllEvent entity)
        //{
        //    await dbSet.AddAsync(entity); 
        //    return true;
        //}

        //public new Task<bool> DeleteAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public new Task<IEnumerable<AllEvent>> FindAsync(Expression<Func<AllEvent, bool>> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IEnumerable<AllEvent>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<AllEvent> GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<bool> UpsertAsync(AllEvent entity)
        //{
        //    throw new NotImplementedException();
        //}

        #region Reference

        //public async Task<bool> DeleteAync(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo)
        //{
        //    try
        //    {
        //        var exist = await GetByIdAsync(FacilNo, LogTypeNo, EventID, EventID_RevNo);

        //        if (exist != null)
        //        {     
        //            dbSet.Remove(exist);
        //            return true;
        //        } else { return false;}
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "{Repo} DeleteAsync Method error", typeof(EmployeeRepository));
        //        return false;
        //    }
        //}


        // Ref: ?
        //public async Task<IList<OrderOverviewDto>> GetFilteredAsync(OrderQueryFilter filter)
        //{
        //    var orders = ordersRepository.GetQueryable()
        //        .AsNoTracking()
        //        .Include(s => s.User)
        //        .Include(x => x.OrderShipment)
        //        .Include(x => x.OrderPayment)
        //        .AsQueryable();

        //    if (filter.Id.HasValue)
        //    {
        //        var order = await orders.FirstOrDefaultAsync(s => s.Id == filter.Id.Value);

        //        if (order == null && filter.UserType == UserType.Admin)
        //        {
        //            throw new StreetwoodException(ErrorCode.OrderNotFound);
        //        }

        //        return mapper.Map<IList<OrderOverviewDto>>(new List<Order> { order });
        //    }

        //    if (filter.UserType == UserType.Customer)
        //    {
        //        orders = orders.Where(s => s.User.Id == filter.UserId);
        //    }

        //    if (filter.DateFrom.HasValue)
        //    {
        //        orders = orders.Where(s => s.CreationDateTime >= filter.DateFrom.Value);
        //    }

        //    if (filter.DateTo.HasValue)
        //    {
        //        orders = orders.Where(s => s.CreationDateTime <= filter.DateTo.Value);
        //    }

        //    if (filter.IsClosed.HasValue)
        //    {
        //        orders = orders.Where(s => s.IsClosed == filter.IsClosed);
        //    }

        //    if (filter.PaymentStatus.HasValue)
        //    {
        //        var paymentStatus = mapper.Map<PaymentStatusDto, PaymentStatus>(filter.PaymentStatus.Value);
        //        orders = orders.Where(s => s.OrderPayment.Status == paymentStatus);
        //    }

        //    if (filter.ShipmentStatus.HasValue)
        //    {
        //        var shipmentStatus = mapper.Map<ShipmentStatusDto, ShipmentStatus>(filter.ShipmentStatus.Value);
        //        orders = orders.Where(s => s.OrderShipment.Status == shipmentStatus);
        //    }

        //    orders = orders.OrderByDescending(x => x.CreationDateTime);

        //    if (filter.Take.HasValue)
        //    {
        //        orders = orders.Take(filter.Take.Value);
        //    }

        //    var ordersList = await orders
        //        .ToListAsync();
        //    return mapper.Map<IList<OrderOverviewDto>>(ordersList);
        //}

        #endregion
    }
}
