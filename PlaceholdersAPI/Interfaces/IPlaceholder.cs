namespace PlaceholdersAPI.Interfaces
{
    public interface IPlaceholder : IPlaceholderHook
    {
        string Name { get; }

        string Identifier { get; }

        string Author { get; }

        string Description { get; }
    }
}
