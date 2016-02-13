using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Command;

namespace HippoBilling.Processor.Commands.Insurances
{
    public class TransposeInsuranceCommand : ICommand
    {
        public Guid SourceId { get; set; }
        public Guid TargetId { get; set; }
    }
}