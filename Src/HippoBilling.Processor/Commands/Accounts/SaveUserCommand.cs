﻿using HippoBilling.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HippoBilling.Processor.Commands.Accounts
{
    public class SaveUserCommand:ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
