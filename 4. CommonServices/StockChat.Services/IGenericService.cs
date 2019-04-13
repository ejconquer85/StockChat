using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockChat.Services
{
    public interface IGenericService<T>
    {
        Task<IList<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task InsertAsync(T entity);

        Task UpdateAsync(T entity);
    }
}