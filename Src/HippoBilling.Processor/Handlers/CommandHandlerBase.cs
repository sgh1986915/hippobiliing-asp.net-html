using HippoBilling.Core.Command;
using HippoBilling.Data;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Processor.Handlers
{
    public abstract class CommandHandlerBase<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand
    {
        protected IRepository Repository { get; set; }

        protected CommandHandlerBase()
        {
            Repository = ServiceLocator.Current.GetInstance<IRepository>();
        }

        public abstract void Handle(TCommand command);
    }
}
