using Obligatorio.Domain.DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IReservationLogic
    {
        Reservation Add(Reservation reservation, int accommodationId);
        Reservation Get(int id);
    }
}
