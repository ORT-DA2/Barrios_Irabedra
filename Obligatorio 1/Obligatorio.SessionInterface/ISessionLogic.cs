using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.SessionInterface
{
    public interface ISessionLogic
    {
        bool IsCorrectToken(string token);
        bool IsValidAdmin(string email, string password);
    }
}
