namespace MCServerLib
{
    public class MCPluginInfo
    {
        public string FilePath { private set; get; }
        public string Name { private set; get; }
        public string Version { private set; get; }
        public string Description { private set; get; }

        public bool IsLoadFailed { private set; get; }

        public MCPluginInfo(string path, string name, string version, string description, bool IsFailed)
        {
            FilePath = path;
            Name = name;
            Version = version;
            Description = description;
            IsLoadFailed = IsFailed;
        }
    }
}
