using Exiled.API.Features;
using PlaceholdersAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholdersTestsFirst
{
    public class ColorPlaceholder : IPlaceholder, IPlaceholderColor
    {
        public string Name => "Color placeholder";

        public string Identifier => "color";

        public string Author => "SpGerg";

        public string Description => "Color placeholder lol";

        public ConsoleColor Color { get; set; } = ConsoleColor.Green;

        public string OnPlaceholderRequest(Player player, string identifier)
        {
            if (identifier == "red")
            {
                Color = ConsoleColor.Red;

                return "red placeholder";
            }

            Color = ConsoleColor.Green;
            return "green placeholder";
        }
    }
}
