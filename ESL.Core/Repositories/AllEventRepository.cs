using Microsoft.EntityFrameworkCore;
using ESL.Core.IRepositories;
using ESL.Core.Data;
using ESL.Core.Models;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ESL.Core.Repositories
{
    public class AllEventRepository : IAllEventRepository
    {
        protected ApplicationDbContext _context;

        internal DbSet<AllEvent> dbSet;

        protected readonly ILogger<AllEventRepository> _logger;

        public AllEventRepository(
            ApplicationDbContext context, ILogger<AllEventRepository> logger)
        {
            this._context = context;
            this.dbSet = context.AllEvents;
            _logger = logger;
        }

        public async Task<IEnumerable<AllEvent>> GetAll(int FacilNo)
        {
            var allEvents = await dbSet.Where(x => x.FacilNo == FacilNo).AsNoTracking().ToListAsync();

            if (allEvents.Any())
            {
                return allEvents;
            }

            return allEvents;
        }

        public async Task<IEnumerable<AllEvent>> GetDefaultAllEventsByFacil(int FacilNo, DateTime startDate, DateTime endDate)
        {
            return await dbSet.Where(x => x.FacilNo == FacilNo & x.EventDate >= startDate & x.EventDate <= endDate).AsNoTracking().ToListAsync();

        }

        public async Task<AllEvent> GetByEvent(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo, AllEvent? allEvent)
        {
            allEvent = await dbSet.FirstOrDefaultAsync(x => x.FacilNo == FacilNo & x.LogTypeNo == LogTypeNo & x.EventID == EventID & x.EventID_RevNo == EventID_RevNo);

            if (allEvent == null) return null;

            return allEvent;
        }

        // refer to the Reference region below
        public async Task<IEnumerable<AllEvent>> FindEvents(Expression<Func<AllEvent, bool>> predicate) => await dbSet.Where(predicate).AsQueryable().AsNoTracking().ToListAsync();

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
