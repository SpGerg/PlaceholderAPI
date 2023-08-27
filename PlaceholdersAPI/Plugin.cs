using Exiled.API.Features;
using Exiled.Loader;

namespace PlaceholdersAPI
{
    public class Plugin : Plugin<Config>
    {
        public static Placeholders.Plugin PlaceholdersPlugin { get; } = (Placeholders.Plugin)Loader.GetPlugin("Placeholders");
    }
}
