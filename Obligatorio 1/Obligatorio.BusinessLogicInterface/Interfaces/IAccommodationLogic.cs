﻿using Obligatorio.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IAccommodationLogic
    {
        List<Accommodation> GetAll();
    }
}
