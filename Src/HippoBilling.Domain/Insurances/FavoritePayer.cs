using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Data;
using HippoBilling.Domain.Practices;

namespace HippoBilling.Domain.Insurances
{
    public class FavoritePayer : Entity
    {
        public Guid PayerId { get; set; }
        public Guid PracticeId { get; set; }
        public virtual Payer Payer { get; set; }
        public virtual Practice Practice { get; set; }
    }
}