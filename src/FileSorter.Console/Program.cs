using FileSorter.Business;
using FileSorter.Business.DirectoryManagers;

var strategies = new Dictionary<char, IDirectoryManager> 
{ 
    { '1', new DateTimeDirectoryManager() },
    { '2', new AlphabetDirectoryManager(new CrossPlatformPath()) },
    { '3', new FileTypeDirectoryManager() },
    { '4', new FileExtensionDirectoryManager() },
    { '5', new XboxDirectoryManager() }
};

Console.WriteLine("Starting...");

var menu =
@"Select a sorting strategy (1, 2, 3, 4, 5):
 1 --> DateTimeDirectoryManager
 2 --> AlphabetDirectoryManager
 3 --> FileTypeDirectoryManager
 4 --> FileExtensionDirectoryManager
 5 --> XboxDirectoryManager";

Console.WriteLine(menu);

var showMenu = true;
while (showMenu)
{
    showMenu = await Sort();
}

async Task<bool> Sort()
{
    var strategyKey = Console.ReadKey();
    if (strategies.TryGetValue(strategyKey.KeyChar, out IDirectoryManager? strategy))
    {
        Console.WriteLine("\nEnter in the source directory:");
        var source = Console.ReadLine();
        Console.WriteLine("\nEnter in the destination directory:");
        var destination = Console.ReadLine();

        ArgumentException.ThrowIfNullOrEmpty(source);
        ArgumentException.ThrowIfNullOrEmpty(destination);

        var files = Directory.GetFiles(source, "*.*", SearchOption.AllDirectories);

        FileDirectory.CreateDirectoryIfNew(destination);
        var organiser = new DirectoryOrganiser(strategy, new FileStreamFactory());
        await organiser.Organise(files, destination);
        return false;
    }
    Console.WriteLine(" Invalid selection.");
    return true;
}

Console.WriteLine("Completed.");
Console.ReadLine();