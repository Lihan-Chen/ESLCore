using ESL.API.Models.BusinessEntities;
using System.Linq.Expressions;

namespace ESL.API.Repositories
{
    // https://medium.com/net-core/repository-pattern-implementation-in-asp-net-core-21e01c6664d7#
    // id_token=eyJhbGciOiJSUzI1NiIsImtpZCI6Ijg3YmJlMDgxNWIwNjRlNmQ0NDljYWM5OTlmMGU1MGU3MmEzZTQzNzQiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2FjY291bnRzLmdvb2dsZS5jb20iLCJhenAiOiIyMTYyOTYwMzU4MzQtazFrNnFlMDYwczJ0cDJhMmphbTRsamRjbXMwMHN0dGcuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJhdWQiOiIyMTYyOTYwMzU4MzQtazFrNnFlMDYwczJ0cDJhMmphbTRsamRjbXMwMHN0dGcuYXBwcy5nb29nbGV1c2VyY29udGVudC5jb20iLCJzdWIiOiIxMDk0OTg3MTI2MzAwODU3Nzk3NDMiLCJlbWFpbCI6ImFsdHAubmV0QGdtYWlsLmNvbSIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJuYmYiOjE3MjA0NTY5NzYsIm5hbWUiOiJMaWhhbiBDaGVuIiwicGljdHVyZSI6Imh0dHBzOi8vbGgzLmdvb2dsZXVzZXJjb250ZW50LmNvbS9hL0FDZzhvY0xBTy0yazV3YWQxNmtFZTdpT1hZZFhxT2I0Rzc3WVJhUnRHcXJCckRtRVRmb2prdz1zOTYtYyIsImdpdmVuX25hbWUiOiJMaWhhbiIsImZhbWlseV9uYW1lIjoiQ2hlbiIsImlhdCI6MTcyMDQ1NzI3NiwiZXhwIjoxNzIwNDYwODc2LCJqdGkiOiIzY2Q4ODg4M2YxOTczODk3ZWJiNjgxM2I2MDFkYzQ4MTViOWIxNGM4In0.QV520lQLfgHN7R5BF5p7-Xkztaj-C9ZG8zDymLmbxSawv-BmGHcYP1S7NtathTPk2EQC8r3tXuZPalJQc9eBAZd7QAyvpA7fg_kiZp8TxreJ8G3micFLc2Hz1FqGERM3pIVOw1aEJHwQxl653twQ92TIwTy6rfhIbQ6c5dr4_ExiSYrgfpDGSTf8LE3YinG1CNs02oPlqt2yESFNzFC3E42-oxxBoDIwwvpXYj9OFoNK7ZFeQ7hqXipE7-CtIEgk2-ZQMLzy2iXRNpKuuvTUn99X7WB6eQiEBIdY-8McIyqvVSvt2Mu_Jnkdze0LfYuBfPFkMQDdA2cuZ9FIOgTPDw

    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int id);

        IEnumerable<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(int id);       
    }
}
