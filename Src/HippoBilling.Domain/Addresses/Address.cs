using HippoBilling.Core.Data;

namespace HippoBilling.Domain.Addresses
{
    public class Address:Entity
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public virtual State State { get; set; }
        public string ZipCode { get; set; }
    }
}
