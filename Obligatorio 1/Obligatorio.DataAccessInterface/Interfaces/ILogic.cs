using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface ILogic<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAllByCondition(Func<T, bool> predicate);
        void Add(T newEntity);
        void Update(int id, T newEntity);
        void Delete(int id);
    }
}
