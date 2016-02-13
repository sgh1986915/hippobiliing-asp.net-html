using HippoBilling.Core.Data;

namespace HippoBilling.Domain.Addresses
{
    public class State:Entity
    {
        public string Name { get; set; }

        public string UpperName { get; set; }

        public string Code { get; set; }
    }
}
