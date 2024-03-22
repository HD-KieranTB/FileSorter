namespace FileSorter.Business
{
    public class CrossPlatformPath : IPath
    {
        public string Combine(string path1, string path2)
        {
            return Path.Combine(path1, path2).Replace('\\', '/');
        }
    }
}
