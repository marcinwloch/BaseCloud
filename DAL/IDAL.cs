using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDAL<K>
    {
        K Get(int id);
        K Find(Func<K, bool> p);
        K Add(K model);
        K Remove(K model);
        K Update(K model);

        K AddOrUpdate(K model);
    }
}
