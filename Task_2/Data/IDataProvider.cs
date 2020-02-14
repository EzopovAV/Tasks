using System;
using System.Collections.Generic;

namespace Task_2.Data
{
    public interface IDataProvider<TEntity, TKey>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(TKey key);
    }
}
