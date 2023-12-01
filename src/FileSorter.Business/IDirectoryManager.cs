namespace FileSorter.Business
{
    public interface IDirectoryManager
    {
        string GetFolderDestination(string destination, FileInfo fileInfo);
        string GetNewFileName(string folderDestination, FileInfo fileInfo);
    }
}