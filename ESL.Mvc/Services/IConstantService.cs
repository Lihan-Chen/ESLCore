using ESL.Core.IRepositories;
using ESL.Core.Models.BusinessEntities;
using Microsoft.Identity.Client;

namespace ESL.Mvc.Services
{
    public interface IConstantService
    {
        // Get List<Constant> per Facility
        public Task<List<Constant>> GetConstantsAsync(int facilNo);
        
        // Get Constant by Id
        public Task<Constant?> GetConstantAsync(int facilNo, string constantName, DateTime startDate);

        public Task<int> UpdateAsync(Constant myConstant, string forceUpdate);

    }

    public class ConstantService : IConstantService
    {
        private readonly IConstantRepository _constantRepository;

        public ConstantService(IConstantRepository constantRepository)
        {
            _constantRepository = constantRepository;
        }

        public async Task<Constant?> GetConstant(int facilNo, string constantName, DateTime startDate)
        {
            return await _constantRepository.GetConstant(facilNo, constantName, startDate);
        }

        //public async Task<List<Constant>> GetConstantAsync(int facilNo)
        //{
        //    return await _constantRepository.GetConstantsByFacil(facilNo);
        //}

        //public async Task<List<Constant>> GetConstantsByFacilAsync(int facilNo)
        //{
        //    return (List<Constant>)await _constantRepository.GetAll();
        //}

        public Task<int> Update(Constant myConstant, string forceUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
