using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Core.Command
{
    public class CommandService : ICommandService
    {
        private readonly IWindsorContainer _container;

        public CommandService(IWindsorContainer container)
        {
            _container = container;
        }

        public virtual void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _container.Resolve<ICommandHandler<TCommand>>();

            //            using (var transaction = new TransactionScope())
            //            {
            handler.Handle(command);
            //                transaction.Complete();
            //            }
        }
    }
}
