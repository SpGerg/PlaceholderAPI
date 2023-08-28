using Exiled.API.Features;
using PlaceholdersAPI.Interfaces;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PlaceholdersAPI.Features
{
    public static class PLAPI
    {
        public static void Register(IPlaceholder placeholder)
        {
            if (Plugin.PlaceholdersPlugin == default)
            {
                throw new NullReferenceException("Plugin \"Placeholders\" not enabled or not found.");
            }

            if (Plugin.PlaceholdersPlugin.Placeholders.Contains(placeholder))
            {
                throw new ArgumentException("Placeholder is contains.");
            }

            if (Plugin.PlaceholdersPlugin.Placeholders.Any(identifier => identifier.Identifier == placeholder.Identifier))
            {
                throw new ArgumentException($"The placeholder named \"{placeholder.Name}\" already has this identifier");
            }

            Plugin.PlaceholdersPlugin.Placeholders.Add(placeholder);

            Log.Send($"Placeholder \"{placeholder.Name}\": was registered", Discord.LogLevel.Info, ConsoleColor.Green);
        }

        public static string SetPlaceholders(Player player, string message)
        {
            string result = message;
            MatchCollection matches = Regex.Matches(result, @"{(\S*)}");

            foreach (Match match in matches)
            {
                string _match = match.Value.Replace("{", "").Replace("}", "");
                IPlaceholder placeholder = Plugin.PlaceholdersPlugin.Placeholders.FirstOrDefault(_placeholder => _placeholder.Identifier == GetIdentifierFromPlaceholder(_match));

                if (placeholder == default)
                {
                    continue;
                }

                string requested = placeholder.OnPlaceholderRequest(player, _match.Replace($"{placeholder.Identifier}_", ""));

                if (placeholder is IPlaceholderColor)
                {
                    requested = $"<color={((IPlaceholderColor)placeholder).Color.ToString().ToLower()}>{requested}</color>";
                }

                result = result.Replace(match.Value, requested);
            }

            return result;
        }

        private static string GetIdentifierFromPlaceholder(string message)
        {
            return message.Split('_').First();
        }
    }
}
