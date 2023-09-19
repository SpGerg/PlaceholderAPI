using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using MEC;
using PlaceholdersAPI.Features;
using PlaceholdersAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Placeholders
{
    public class Plugin : Plugin<Config>
    {
        public override PluginPriority Priority => PluginPriority.Last;

        public List<IPlaceholder> Placeholders { get; private set; } = new List<IPlaceholder>();

        public override void OnEnabled()
        {
            if (Config.IsChangePlaceholdersInConfigs)
            {
                foreach (IPlugin<IConfig> plugin in Server.PluginAssemblies.Values)
                {
                    Type type = plugin.Config.GetType();

                    foreach (PropertyInfo property in type.GetProperties())
                    {
                        if (property.PropertyType == typeof(string))
                        {
                            property.SetValue(plugin.Config, PLAPI.SetPlaceholders(null, (string)property.GetValue(plugin.Config)));
                        }
                    }
                }
            }

            Timing.RunCoroutine(UpdateHints());

            base.OnEnabled();
        }

        private IEnumerator<float> UpdateHints()
        {
            while (true)
            {
                foreach (var player in Player.List)
                {
                    if (player.CurrentHint == null) continue;

                    player.CurrentHint.Content = PLAPI.SetPlaceholders(player, player.CurrentHint.Content);
                }

                yield return Timing.WaitForOneFrame;
            }
        }
    }
}
