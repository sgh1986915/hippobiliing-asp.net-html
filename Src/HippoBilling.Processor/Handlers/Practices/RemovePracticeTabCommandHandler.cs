using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Practices;
using HippoBilling.Processor.Commands.Practices;

namespace HippoBilling.Processor.Handlers.Practices
{
    public class RemovePracticeTabCommandHandler:CommandHandlerBase<RemovePracticeTabCommand>
    {
        public override void Handle(RemovePracticeTabCommand command)
        {
            var practiceUser =
                Repository.Query<PracticeUser>()
                    .FirstOrDefault(x => x.UserId == command.UserId && x.PracticeId == command.PracticeId);
            if(practiceUser==null) throw new ErrorException("The user was not assigned to the practice.");

            practiceUser.ShowInTab = false;

            Repository.Update(practiceUser);
        }
    }
}
