﻿using Obligatorio.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IAdminLogic
    {
        bool IsValidAdmin(string email, string password);
        void Add(Admin adminToRegister);
    }
}
