using System.Collections.Generic;
using Tensee.Banch.Caching.Dto;

namespace Tensee.Banch.Web.Areas.AppAreaName.Models.Maintenance
{
    public class MaintenanceViewModel
    {
        public IReadOnlyList<CacheDto> Caches { get; set; }
    }
}