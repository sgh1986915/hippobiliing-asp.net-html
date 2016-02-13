using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Core.Command
{
    public interface ICommandService
    {
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
