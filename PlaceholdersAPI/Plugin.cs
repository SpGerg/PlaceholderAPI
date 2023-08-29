using Discord;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Interfaces;
using HarmonyLib;
using PlaceholdersAPI.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PlaceholdersAPI
{
    public class Plugin : Plugin<Config>
    {
        public override PluginPriority Priority => PluginPriority.First;

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

            base.OnEnabled();
        }
    }
}
