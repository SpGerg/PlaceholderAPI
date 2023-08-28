using Exiled.API.Features;

namespace PlaceholdersAPI.Interfaces
{
    public interface IPlaceholderHook
    {
        string OnPlaceholderRequest(Player player, string identifier);
    }
}
