namespace FileSorter.Business
{
    public sealed class FileTypeDirectoryManager : IDirectoryManager
    {
        public string GetFolderDestination(string destination, IReadonlyFileInfo fileInfo)
        {
            var folder = "Other";
            if (ExtensionTypes.IMAGE_EXTENSIONS.Contains(fileInfo.Extension))
            {
                folder = "Images";
            }
            if (ExtensionTypes.VIDEO_EXTENSIONS.Contains(fileInfo.Extension))
            {
                folder = "Videos";
            }
            if (ExtensionTypes.SOUND_EXTENSIONS.Contains(fileInfo.Extension))
            {
                folder = "Sounds";
            }
            if (ExtensionTypes.DOCUMENT_EXTENSIONS.Contains(fileInfo.Extension))
            {
                folder = "Documents";
            }
            if (ExtensionTypes.ARCHIVE_EXTENSIONS.Contains(fileInfo.Extension))
            {
                folder = "Archive";
            }

            return Path.Combine(destination, folder);
        }

        public string GetNewFileName(string folderDestination, IReadonlyFileInfo fileInfo)
        {
            return Path.Combine(folderDestination, Path.GetFileName(fileInfo.FullName));
        }
    }
}