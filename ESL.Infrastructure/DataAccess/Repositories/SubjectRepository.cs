using ESL.Application.Interfaces.IRepositories;
using ESL.Core.Models.BusinessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESL.Infrastructure.DataAccess.Repositories
{
    public class SubjectRepository(EslDbContext context, ILogger<SubjectRepository> logger) : ISubjectRepository
    {
        private readonly EslDbContext _context = context ?? throw new ArgumentNullException(nameof(context));
        private readonly ILogger<SubjectRepository> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public IQueryable<Subject> GetSubject(int facilNo, int subjNo)
        {
            return _context.Subjects
                .AsNoTracking()
                .TagWith("GetSubject")
                .Where(s => s.FacilNo == facilNo && s.SubjNo == subjNo);
        }

        public IQueryable<Subject> GetSubjectList(int facilNo)
        {
            return _context.Subjects
                .AsNoTracking()
                .TagWith("GetSubjectList")
                .Where(s => s.FacilNo == facilNo)
                .OrderBy(s => s.SubjName);
        }
    }
}
