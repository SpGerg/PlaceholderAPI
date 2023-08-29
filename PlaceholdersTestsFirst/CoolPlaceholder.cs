using Exiled.API.Features;
using PlaceholdersAPI.Interfaces;

namespace PlaceholdersTestsFirst
{
    //Cool placeholder
    public class CoolPlaceholder : IPlaceholder, IPlaceholderHook
    {
        public string Name => "Cool placeholder";

        //All placeholders in method OnPlaceholderRequest like this: cool_placeholder, identifier_placeholder
        public string Identifier => "cool";

        public string Author => "SpGerg";

        public string Description => "Just cool placeholder, lol.";

        public string OnPlaceholderRequest(string identifier)
        {
            if (identifier == "placeholder")
            {
                return "Coolest placeholder in the world.";
            }
            else if (identifier == "placeholder2")
            {
                return "Coolest placeholder again?";
            }

            return null;
        }
    }
}
