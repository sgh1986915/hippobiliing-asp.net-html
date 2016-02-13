using HippoBilling.Data;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Service
{
    public class ServiceBase
    {
         protected IRepository Repository { get; set; }

         protected ServiceBase()
        {
            Repository = ServiceLocator.Current.GetInstance<IRepository>();
        }
    }
}
