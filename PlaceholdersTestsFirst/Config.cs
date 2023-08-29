using Exiled.API.Interfaces;

namespace PlaceholdersTestsFirst
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }

        public bool Debug { get; set; }

        public string SomeTextWithPlaceholder { get; set; } = "Some text with {cool_placeholder}";
    }
}
