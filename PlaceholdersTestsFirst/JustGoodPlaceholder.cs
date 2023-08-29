using Exiled.API.Features;
using PlaceholdersAPI.Interfaces;

namespace PlaceholdersTestsFirst
{
    public class JustGoodPlaceholder : IPlaceholder
    {
        public string Name => "This is just good placeholder";

        public string Identifier => "just-good";

        public string Author => "SpGerg";

        public string Description => "Just good description.";

        public string OnPlaceholderRequest(Player player, string identifier)
        {
            if (identifier == "placeholder2")
            {
                return "Hello, world!";
            }

            return null;
        }
    }
}
