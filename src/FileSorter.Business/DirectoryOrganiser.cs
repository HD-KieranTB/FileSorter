using FileSorter.Business.DirectoryManagers;

namespace FileSorter.Business
{
    public class DirectoryOrganiser
    {
        private readonly IDirectoryManager _directoryManager;
        private readonly IStreamFactory _streamFactory;

        public DirectoryOrganiser(IDirectoryManager directoryManager, IStreamFactory streamFactory)
        {
            _directoryManager = directoryManager;
            _streamFactory = streamFactory;
        }

        public async Task Organise(string[] files, string destination)
        {
            await Parallel.ForEachAsync(files, async (file, token) =>
            {
                var fileInfo = new ReadonlyFileInfo(new FileInfo(file));
                await Console.Out.WriteLineAsync($"Copying: '{fileInfo.Name}'. Size: '{fileInfo.Length}'.");

                var folderDestination = _directoryManager.GetFolderDestination(destination, fileInfo);

                var newName = _directoryManager.GetNewFileName(folderDestination, fileInfo);
                if (File.Exists(newName))
                {
                    return;
                }

                FileDirectory.CreateDirectoryIfNew(folderDestination);

                using var sourceStream = _streamFactory.CreateSourceStream(file);
                    using var destinationStream = _streamFactory.CreateDestinationStream(newName);
                        await sourceStream.CopyToAsync(destinationStream, token);

                await Console.Out.WriteLineAsync($"Finished copying: '{fileInfo.Name}'. Size: '{fileInfo.Length}'.");
            });
        }
    }
}
