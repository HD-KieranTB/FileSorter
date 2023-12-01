namespace FileSorter.Business
{
    public class Organiser
    {
        private readonly IDirectoryManager _directoryManager;

        public Organiser(IDirectoryManager directoryManager)
        {
            _directoryManager = directoryManager;
        }

        public async Task Organise(string[] files, string destination)
        {
            await Parallel.ForEachAsync(files, async (file, token) =>
            {
                var fileInfo = new FileInfo(file);
                await Console.Out.WriteLineAsync($"Copying: '{fileInfo.Name}'. Size: '{fileInfo.Length}'.");

                var folderDestination = _directoryManager.GetFolderDestination(destination, fileInfo);

                var newName = _directoryManager.GetNewFileName(folderDestination, fileInfo);
                if (File.Exists(newName))
                {
                    return;
                }

                FileDirectory.CreateDirectoryIfNew(folderDestination);

                using var sourceStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);
                using var destinationStream = new FileStream(newName, FileMode.CreateNew, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true);
                await sourceStream.CopyToAsync(destinationStream, token);
                await Console.Out.WriteLineAsync($"Finished copying: '{fileInfo.Name}'. Size: '{fileInfo.Length}'.");
            });
        }
    }
}
