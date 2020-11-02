using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserBase.DataAccess.Repositories
{
    public interface IRepository<T>
    {
        Task Add(T entity);
        Task Edit(T entity);
        Task Delete(T entity);
        Task<T> GetById(int id);
        Task<IList<T>> GetAll();
        Task DeleteAll();
    }
}
