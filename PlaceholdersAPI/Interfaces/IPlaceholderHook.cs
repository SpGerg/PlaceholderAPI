﻿using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholdersAPI.Interfaces
{
    public interface IPlaceholderHook
    {
        string OnPlaceholderRequest(string identifier);
    }
}
