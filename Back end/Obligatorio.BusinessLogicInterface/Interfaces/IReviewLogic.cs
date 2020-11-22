using Obligatorio.Model.Models.In;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IReviewLogic
    {
        void AddReview(ReviewRegistrationModelIn reviewRegistrationModelIn);
    }
}
