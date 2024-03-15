namespace FileSorter.Business.DirectoryManagers
{
    public sealed class DateTimeDirectoryManager : IDirectoryManager
    {
        public string GetFolderDestination(string destination, IReadonlyFileInfo fileInfo)
        {
            var folder = fileInfo.LastWriteTime.Year.ToString();
            return Path.Combine(destination, folder);
        }

        public string GetNewFileName(string folderDestination, IReadonlyFileInfo fileInfo)
        {
            return Path.Combine(folderDestination, $"{fileInfo.LastWriteTime:dd MMM yyyy HHmmss} [{fileInfo.Name}]{fileInfo.Extension}");
        }
    }
}