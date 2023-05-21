using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TM.Application.Contracts.Persistence
{

    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<T> Get(string id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task<bool> Exists(int id);
        Task<bool> Exists(string id);
        Task Update(T entity);
        Task Delete(T entity);
    }

}