using Microsoft.EntityFrameworkCore;
using ESL.Core.IRepositories;
using ESL.Core.Data;
using ESL.Core.Models;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography.X509Certificates;

namespace ESL.Core.Repositories
{
    public class AllEventRepository : IAllEventRepository
    {
        protected ApplicationDbContext _context;

        internal DbSet<AllEvent> dbSet;

        protected readonly ILogger _logger;

        public AllEventRepository(
            ApplicationDbContext context, ILogger logger)
        {
            this._context = context;
            this.dbSet = context.AllEvents;
            _logger = logger;
        }

        public async Task<IEnumerable<AllEvent>> GetAll(int facilNo)
        {
            return await dbSet.Where(x => x.FacilNo == facilNo).ToListAsync();

        }

        public async Task<IEnumerable<AllEvent>> GetDefaultAllEventsByFacil(int facilNo, DateTime startDate, DateTime endDate)
        {
            return await dbSet.Where(x => x.FacilNo == facilNo & x.EventDate >= startDate & x.EventDate <= endDate).AsNoTracking().ToListAsync();

        }

        public async Task<AllEvent> GetByEvent(int facilNo, int logTypeNo, string eventID, int eventID_RevNo, AllEvent? allEvent)
        {
            allEvent = await dbSet.FirstOrDefaultAsync(x => x.FacilNo == facilNo & x.LogTypeNo == logTypeNo & x.EventID == eventID & x.EventID_RevNo == eventID_RevNo);

            if (allEvent == null) return null;

            return allEvent;

        }

        // refer to the Reference region below
        public async Task<IEnumerable<AllEvent>> FindEvents(Expression<Func<AllEvent, bool>> predicate) => await dbSet.AsQueryable().AsNoTracking().ToListAsync();

        //public async AllEvent? GetAllEvent(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        //{
        //    return await dbSet.FirstOrDefaultAsync(x => x.FacilNo == facilNo & x.LogTypeNo == logTypeNo & x.EventID == eventID & x.EventID_RevNo == eventID_RevNo);
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

        //public async Task<bool> DeleteAync(int facilNo, int logTypeNo, string eventID, int eventID_RevNo)
        //{
        //    try
        //    {
        //        var exist = await GetByIdAsync(facilNo, logTypeNo, eventID, eventID_RevNo);

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
