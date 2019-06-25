using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestApp.DbContextHelper
{
    //public class FakeDbSet<T> : IDbSet<T>
    //where T : class
    //{
    //    HashSet<T> _data;
    //    IQueryable _query;

    //    public FakeDbSet()
    //    {
    //        _data = new HashSet<T>();
    //        _query = _data.AsQueryable();
    //    }

    //    public virtual T Find(params object[] keyValues)
    //    {
    //        throw new NotImplementedException("Derive from FakeDbSet<T> and override Find");
    //    }
    //    public void Add(T item)
    //    {
    //        _data.Add(item);
    //    }

    //    public void Remove(T item)
    //    {
    //        _data.Remove(item);
    //    }

    //    public void Attach(T item)
    //    {
    //        _data.Add(item);
    //    }
    //    public void Detach(T item)
    //    {
    //        _data.Remove(item);
    //    }
    //    Type IQueryable.ElementType
    //    {
    //        get { return _query.ElementType; }
    //    }
    //    System.Linq.Expressions.Expression IQueryable.Expression
    //    {
    //        get { return _query.Expression; }
    //    }

    //    IQueryProvider IQueryable.Provider
    //    {
    //        get { return _query.Provider; }
    //    }
    //    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    //    {
    //        return _data.GetEnumerator();
    //    }
    //    IEnumerator<T> IEnumerable<T>.GetEnumerator()
    //    {
    //        return _data.GetEnumerator();
    //    }
    //}
}
