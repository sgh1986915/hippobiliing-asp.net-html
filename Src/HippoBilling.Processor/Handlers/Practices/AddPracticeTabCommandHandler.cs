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
    public class AddPracticeTabCommandHandler:CommandHandlerBase<AddPracticeTabCommand>
    {
        private const int MaxTabCount = 10;
        public override void Handle(AddPracticeTabCommand command)
        {
            var practiceUser =
              Repository.Query<PracticeUser>()
                  .FirstOrDefault(x => x.UserId == command.UserId && x.PracticeId == command.PracticeId);
            if (practiceUser == null) throw new ErrorException("The user was not assigned to the practice.");

            var tabsCount =
                Repository.Query<PracticeUser>()
                    .Count(x => x.UserId == command.UserId && x.PracticeId != command.PracticeId);
            if(tabsCount>=MaxTabCount) throw new ErrorException("You may select up to 10 tab, pelase remove one if you want to select this.");
            practiceUser.ShowInTab = true;
            Repository.Update(practiceUser);
        }
    }
}
