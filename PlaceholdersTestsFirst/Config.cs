using Exiled.API.Interfaces;

namespace PlaceholdersTestsFirst
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }

        public bool Debug { get; set; }
    }
}
