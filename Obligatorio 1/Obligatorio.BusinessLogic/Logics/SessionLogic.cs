using Obligatorio.SessionInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.BusinessLogic.Logics
{
    public class SessionLogic : ISessionLogic
    {
        public bool IsCorrectToken(string token)
        {
            return token == "admin";
        }

        public bool IsValidAdmin(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
