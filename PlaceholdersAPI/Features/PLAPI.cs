using Exiled.API.Features;
using Exiled.Loader;
using HarmonyLib;
using PlaceholdersAPI.Interfaces;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PlaceholdersAPI.Features
{
    public static class PLAPI
    {
        public static Placeholders.Plugin PlaceholdersPlugin { get; } = (Placeholders.Plugin)Loader.GetPlugin("Placeholders");

        public static void Register(IPlaceholder placeholder)
        {
            if (PlaceholdersPlugin == default)
            {
                throw new NullReferenceException("Plugin \"Placeholders\" not enabled or not found.");
            }

            if (string.IsNullOrWhiteSpace(placeholder.Identifier))
            {
                throw new ArgumentException("Placeholder identifier is null or whitespace.");
            }

            if (PlaceholdersPlugin.Placeholders.Contains(placeholder))
            {
                throw new ArgumentException("Placeholder is contains.");
            }

            if (PlaceholdersPlugin.Placeholders.Any(identifier => identifier.Identifier == placeholder.Identifier))
            {
                throw new ArgumentException($"The placeholder named \"{placeholder.Name}\" already has this identifier");
            }

            PlaceholdersPlugin.Placeholders.Add(placeholder);

            Log.Send($"Placeholder \"{placeholder.Name}\": was registered", Discord.LogLevel.Info, ConsoleColor.Green);
        }

        public static string SetPlaceholders(Player player, string message)
        {
            string result = message;
            MatchCollection matches = Regex.Matches(result, @"{(\S*)}");

            foreach (Match match in matches)
            {
                string _match = match.Value.Replace("{", "").Replace("}", "");
                IPlaceholder placeholder = PlaceholdersPlugin.Placeholders.FirstOrDefault(_placeholder => _placeholder.Identifier == GetIdentifierFromPlaceholder(_match));

                if (placeholder == default)
                {
                    continue;
                }

                string requested = string.Empty;

                if (placeholder is IPlaceholderHook placeholderHook)
                {
                    requested = placeholderHook.OnPlaceholderRequest(_match.Replace($"{placeholder.Identifier}_", ""));
                }

                if (placeholder is IPlaceholderHookPlayer placeholderHookPlayer)
                {
                    requested = placeholderHookPlayer.OnPlaceholderRequest(player, _match.Replace($"{placeholder.Identifier}_", ""));
                }

                if (placeholder is IPlaceholderColor placeholderColor)
                {
                   requested = $"<color={placeholderColor.Color.ToString().ToLower()}>{requested}</color>";
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
