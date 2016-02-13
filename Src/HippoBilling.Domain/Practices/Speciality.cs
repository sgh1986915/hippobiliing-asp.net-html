using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Data;

namespace HippoBilling.Domain.Practices
{
   public class Speciality:Entity
   {
       public string Name { get; set; }

       public string Code { get; set; }

       public string Description { get; set; }
   }
}
