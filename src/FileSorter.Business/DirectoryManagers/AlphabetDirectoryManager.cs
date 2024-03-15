namespace FileSorter.Business.DirectoryManagers
{
    public sealed class AlphabetDirectoryManager : IDirectoryManager
    {
        private const string OTHER = "Other";

        public string GetFolderDestination(string destination, IReadonlyFileInfo fileInfo)
        {
            if (!char.IsLetter(fileInfo.Name[0])) return Path.Combine(destination, OTHER);

            var folder = fileInfo.Name[0].ToString().ToUpper();

            return Path.Combine(destination, folder);
        }

        public string GetNewFileName(string folderDestination, IReadonlyFileInfo fileInfo)
        {
            return Path.Combine(folderDestination, $"{Path.GetFileNameWithoutExtension(fileInfo.FullName)} {fileInfo.LastWriteTime:dd MMM yyyy HHmmss}{fileInfo.Extension}");
        }
    }
}