﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSFOLCrossPlatform
{
    public interface ISaveAndLoad
    {
        string SaveText(string filename, string text);
    }
}
