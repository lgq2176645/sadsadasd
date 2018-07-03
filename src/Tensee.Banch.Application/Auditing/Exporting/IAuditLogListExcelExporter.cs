using System.Collections.Generic;
using Tensee.Banch.Auditing.Dto;
using Tensee.Banch.Dto;

namespace Tensee.Banch.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
