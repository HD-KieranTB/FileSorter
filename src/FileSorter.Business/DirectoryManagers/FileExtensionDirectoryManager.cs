namespace FileSorter.Business.DirectoryManagers
{
    public sealed class FileExtensionDirectoryManager : IDirectoryManager
    {
        public string GetFolderDestination(string destination, IReadonlyFileInfo fileInfo)
        {
            var folder = fileInfo.Extension[1..];

            return Path.Combine(destination, folder.ToLower());
        }

        public string GetNewFileName(string folderDestination, IReadonlyFileInfo fileInfo)
        {
            return Path.Combine(folderDestination, Path.GetFileName(fileInfo.FullName));
        }
    }
}