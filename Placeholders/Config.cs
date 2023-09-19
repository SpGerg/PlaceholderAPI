using Exiled.API.Interfaces;

namespace Placeholders
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }

        public bool Debug { get; set; }

        public bool IsChangePlaceholdersInConfigs { get; set; }
    }
}
