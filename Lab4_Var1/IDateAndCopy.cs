﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Var1
{
    public interface IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }
    }
}
