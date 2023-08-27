using Exiled.API.Features;

namespace PlaceholdersAPI
{
    public interface IPlaceholderHook
    {
        string OnPlaceholderRequest(Player player, string identifier);
    }
}
