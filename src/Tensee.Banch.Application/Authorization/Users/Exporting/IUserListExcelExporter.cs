using System.Collections.Generic;
using Tensee.Banch.Authorization.Users.Dto;
using Tensee.Banch.Dto;

namespace Tensee.Banch.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}