namespace FileSorter.Business
{
    public sealed class AlphabetDirectoryManager : IDirectoryManager
    {
        public string GetFolderDestination(string destination, FileInfo fileInfo)
        {
            var folder = fileInfo.Name[0].ToString().ToUpper();
            return Path.Combine(destination, folder);
        }

        public string GetNewFileName(string folderDestination, FileInfo fileInfo)
        {
            return Path.Combine(folderDestination, $"{Path.GetFileNameWithoutExtension(fileInfo.FullName)} {fileInfo.LastWriteTime:dd MMM yyyy HHmmss}{fileInfo.Extension}");
        }
    }
}