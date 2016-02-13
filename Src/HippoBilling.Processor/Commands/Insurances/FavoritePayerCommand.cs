using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Command;

namespace HippoBilling.Processor.Commands.Insurances
{
    public class FavoritePayerCommand : ICommand
    {
        public Guid PracticeId { get; set; }
        public Guid PayerId { get; set; }
    }
}