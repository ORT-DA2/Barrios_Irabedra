using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.DataAccessInterface.Interfaces
{
    public interface IAdminRepository
    {
        bool IsValidAdmin(string email, string password);
    }
}
