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
            return true;
        }
    }
}
