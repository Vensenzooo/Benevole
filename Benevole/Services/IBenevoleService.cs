using Benevole.Models;

namespace Benevole.Services
{
    public interface IBenevoleService
    {
        Task<IEnumerable<BenevoleModel>> GetAllAsync();
        Task<BenevoleModel?> GetByIdAsync(int id);
        Task AddAsync(BenevoleModel benevole);
        Task UpdateAsync(BenevoleModel benevole);
        Task DeleteAsync(int id);
    }
}