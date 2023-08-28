using Exiled.API.Enums;
using Exiled.API.Features;
using PlaceholdersAPI.Interfaces;
using System.Collections.Generic;

namespace Placeholders
{
    public class Plugin : Plugin<Config>
    {
        public override PluginPriority Priority => PluginPriority.First;

        public List<IPlaceholder> Placeholders { get; private set; }

        public override void OnEnabled()
        {
            Placeholders = new List<IPlaceholder>();

            base.OnEnabled();
        }
    }
}
