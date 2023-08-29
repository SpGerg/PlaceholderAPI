using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholdersAPI.Interfaces
{
    public interface IPlaceholderInfo
    {
        string Name { get; }

        string Identifier { get; }

        string Author { get; }

        string Description { get; }
    }
}
