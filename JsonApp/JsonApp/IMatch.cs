﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonApp
{
    public interface IMatch
    {
        bool Success();
        string RemainingText();
    }
}
