﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Command
{
    public interface ICommand
    {
        //Execute
        void Execute();

        //UnExecute
        void ReverseExecute();
    }
}
