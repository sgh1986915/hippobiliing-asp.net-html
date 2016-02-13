using System.ComponentModel;
using HippoBilling.Core.Resources;

namespace HippoBilling.Core.Authorization
{
    [TypeConverter(typeof(CoreEnumConverter))]
    public enum Permission
    {
        FullControl=0,
        View=1,
        Edit=2,
        Delete=3
    }
}
