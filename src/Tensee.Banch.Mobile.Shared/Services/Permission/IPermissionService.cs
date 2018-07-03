namespace Tensee.Banch.Services.Permission
{
    public interface IPermissionService
    {
        bool HasPermission(string key);
    }
}