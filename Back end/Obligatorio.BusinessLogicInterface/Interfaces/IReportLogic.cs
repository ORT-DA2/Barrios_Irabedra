using Obligatorio.Model.Models.In;
using Obligatorio.Model.Models.Out;
using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.BusinessLogicInterface.Interfaces
{
    public interface IReportLogic
    {
        List<ReportLineModelOut> GetReports(ReportModelIn reportModelIn);
    }
}
