namespace FileSorter.Business
{
    public sealed class FileExtensionDirectoryManager : IDirectoryManager
    {
        public string GetFolderDestination(string destination, FileInfo fileInfo)
        {
            var folder = fileInfo.Extension[1..];

            return Path.Combine(destination, folder);
        }

        public string GetNewFileName(string folderDestination, FileInfo fileInfo)
        {
            return Path.Combine(folderDestination, Path.GetFileName(fileInfo.FullName));
        }
    }
}