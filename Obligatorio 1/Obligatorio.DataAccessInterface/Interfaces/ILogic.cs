using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface ILogic<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
