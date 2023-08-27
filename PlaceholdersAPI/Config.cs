using Exiled.API.Interfaces;

namespace PlaceholdersAPI
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }

        public bool Debug { get; set; }
    }
}
