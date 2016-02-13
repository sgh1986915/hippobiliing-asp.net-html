namespace HippoBilling.Core.Authorization
{
    public interface IPermissionModule
    {
        string ModuleName { get; }
        int Order { get; }
    }
}
