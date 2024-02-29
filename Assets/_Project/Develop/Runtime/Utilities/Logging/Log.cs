namespace Develop.Runtime.Utilities.Logging
{
    public static class Log
    {
        public static readonly TagLog Default = new(string.Empty);
        public static readonly TagLog Loading = new("LOADING");
        public static readonly TagLog Boot = new("BOOT");
        public static readonly TagLog Meta = new("META");
        public static readonly TagLog Core = new("CORE");

        public static readonly BuilderLogPool Builder = new(new TagLog(string.Empty), 5);
    }
}