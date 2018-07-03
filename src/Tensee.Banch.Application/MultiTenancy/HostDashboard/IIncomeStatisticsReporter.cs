using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tensee.Banch.MultiTenancy.HostDashboard.Dto;

namespace Tensee.Banch.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}