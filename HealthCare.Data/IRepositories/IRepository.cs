

namespace HealthCare.Data.IRepositories
{
    public interface IRepository<TResult>
    {
        Task<TResult> CreateAsync(TResult value);
        Task<TResult> UpdateAsync(long id, TResult value);
        Task<bool> DeleteAsync(long id);
        Task<TResult> GetByIdAsync(long id);
        Task<List<TResult>> GetAllAsync();
        
    }
}
