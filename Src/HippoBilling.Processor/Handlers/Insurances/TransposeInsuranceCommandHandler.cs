using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Exception;
using HippoBilling.Domain.Insurances;
using HippoBilling.Processor.Commands.Insurances;

namespace HippoBilling.Processor.Handlers.Insurances
{
    public class TransposeInsuranceCommandHandler : CommandHandlerBase<TransposeInsuranceCommand>
    {
        public override void Handle(TransposeInsuranceCommand command)
        {
            var source = Repository.Get<Insurance>(command.SourceId);
            if (source == null) throw new ErrorException("The source insurance does not exist.");
            var target = Repository.Get<Insurance>(command.TargetId);
            if (target == null) throw new ErrorException("The target insurance does not exist.");

            int order = source.Order;
            source.Order = target.Order;
            target.Order = order;
            Repository.UpdateRange(new[] {source, target});
        }
    }
}