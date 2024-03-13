using System.Text.RegularExpressions;

namespace FileSorter.Business.DirectoryManagers
{
    public sealed class XboxDirectoryManager : IDirectoryManager
    {
        public string GetFolderDestination(string destination, IReadonlyFileInfo fileInfo)
        {
            var gameAndDate = fileInfo.Name.Split('-');

            var gamePart = new string(gameAndDate[0].Trim().Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());
            gamePart = Regex.Replace(gamePart, @"\s+", " ");

            var subFolder = "Clips";
            if (ExtensionTypes.IMAGE_EXTENSIONS.Contains(fileInfo.Extension))
            {
                subFolder = "Screenshots";
            }
            var combined = Path.Combine(gamePart, subFolder);
            return Path.Combine(destination, combined);
        }

        public string GetNewFileName(string folderDestination, IReadonlyFileInfo fileInfo)
        {
            return Path.Combine(folderDestination, Path.GetFileName(fileInfo.FullName));
        }
    }
}