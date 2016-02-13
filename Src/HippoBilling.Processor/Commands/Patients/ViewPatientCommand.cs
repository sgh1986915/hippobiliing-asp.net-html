using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HippoBilling.Core.Command;

namespace HippoBilling.Processor.Commands.Patients
{
    public class ViewPatientCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}