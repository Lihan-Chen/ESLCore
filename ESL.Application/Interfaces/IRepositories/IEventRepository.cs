﻿using ESL.Core.Interfaces;
using System.Linq.Expressions;

namespace ESL.Application.Interfaces.IRepositories
{
    public interface IEventRepository
    {
        // This interface is for AllEvent class, not for any concrete log type which is based on ILogEventEntity
        public interface IEventRepository<TEntity> where TEntity : ILogEventEntity
        {
            #region Queries

            Task<IEnumerable<TEntity>> GetAll();

            Task<TEntity> GetByEvent(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo);

            Task<IEnumerable<TEntity>> FindEvent(Expression<Func<TEntity, bool>> predicate);

            Task<IEnumerable<TEntity>> GetOutstandingEvents(int FacilNo, int LogTypeNo);

            Task<IEnumerable<TEntity>> GetAllEvents(int FacilNo, int LogTypeNo, DateTime startDate, DateTime endDate);

            #endregion

            #region Commands

            Task<bool> AddEvent(TEntity entity);

            // Soft Delete
            Task<bool> DeleteEvent(int FacilNo, int LogTypeNo, string EventID, int EventID_RevNo);

            // Mark the original entiry as revised or modified, and create a new entity with new revision number
            Task<bool> Upsert(TEntity entity);

            #endregion
        }
    }
}
