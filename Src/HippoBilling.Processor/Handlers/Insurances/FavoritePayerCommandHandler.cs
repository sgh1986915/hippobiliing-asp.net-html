using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Insurances;
using HippoBilling.Domain.Practices;
using HippoBilling.Processor.Commands.Insurances;

namespace HippoBilling.Processor.Handlers.Insurances
{
    public class FavoritePayerCommandHandler : CommandHandlerBase<FavoritePayerCommand>
    {
        public override void Handle(FavoritePayerCommand command)
        {
            if (Repository.Query<FavoritePayer>()
                .Any(x => x.PayerId == command.PayerId && x.PracticeId == command.PracticeId)) return;

            var payer = Repository.Get<Payer>(command.PayerId);
            if (payer == null) throw new ErrorException("The Payer does not exist.");
            var practice = Repository.Get<Practice>(command.PracticeId);
            if (practice == null) throw new ErrorException("The Practice does not exist.");

            Repository.Create(new FavoritePayer() {Payer = payer, Practice = practice});
        }
    }
}