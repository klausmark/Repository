using System.Collections.Generic;

namespace Repository
{
    public interface IRepository<TItem, TId> where TItem : IValueItem<TId>
    {
        IEnumerable<TItem> GetAll();
        TItem Get(TId id);
        void Add(TItem item);
        void Remove(TId id);
        void Remove(TItem item);
        void Update(TItem item);
    }
}