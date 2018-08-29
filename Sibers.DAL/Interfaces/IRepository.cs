using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;

namespace Sibers.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IPagedList<T> GetAllIndex(int pageNumber, int pageSize, string search);
        T Get(Guid id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
        Task<T> GetAsync(Guid? id);
    }
}
