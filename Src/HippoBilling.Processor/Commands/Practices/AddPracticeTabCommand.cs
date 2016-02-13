using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Command;

namespace HippoBilling.Processor.Commands.Practices
{
    public class AddPracticeTabCommand:ICommand
    {
        public Guid UserId { get; set; }

        public Guid PracticeId { get; set; }
    }
}
