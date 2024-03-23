using FileSorter.Business;
using FileSorter.Business.DirectoryManagers;

namespace FileSorter.Console
{
    internal static class ConsoleMenu
    {
        private static readonly CrossPlatformPath __path = new();

        private static readonly IDictionary<char, IDirectoryManager> __strategies = new Dictionary<char, IDirectoryManager>
            {
                { '1', new DateTimeDirectoryManager(__path) },
                { '2', new AlphabetDirectoryManager(__path) },
                { '3', new FileTypeDirectoryManager(__path) },
                { '4', new FileExtensionDirectoryManager(__path) },
                { '5', new XboxDirectoryManager(__path) },
                { '6', new LibraryDirectoryManager(__path) }
            };

        private static readonly string __options = 
            @$"Select a sorting strategy ({string.Join(", ", __strategies.Keys)}):

    1 --> DateTimeDirectoryManager
    2 --> AlphabetDirectoryManager
    3 --> FileTypeDirectoryManager
    4 --> FileExtensionDirectoryManager
    5 --> XboxDirectoryManager
    6 --> LibraryDirectoryManager";

        public static void PrintOptions()
        {
            System.Console.WriteLine();
            System.Console.WriteLine(__options);
        }

        public static async Task Run()
        {
            var isRunning = true;
            while (isRunning)
            {
                var strategyKey = System.Console.ReadKey();
                if (__strategies.TryGetValue(strategyKey.KeyChar, out IDirectoryManager? strategy))
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Enter in the source directory:");
                    var source = System.Console.ReadLine();
                    System.Console.WriteLine();
                    System.Console.WriteLine("Enter in the destination directory:");
                    var destination = System.Console.ReadLine();

                    ArgumentException.ThrowIfNullOrEmpty(source);
                    ArgumentException.ThrowIfNullOrEmpty(destination);

                    var files = Directory.GetFiles(source, "*.*", SearchOption.AllDirectories);

                    FileDirectory.CreateDirectoryIfNew(destination);
                    var organiser = new DirectoryOrganiser(strategy, new FileStreamFactory(), new DirectoryOrganiserConsoleView());
                    await organiser.Organise(files, destination);

                    System.Console.WriteLine();
                    System.Console.WriteLine("Completed.");

                    System.Console.WriteLine();
                    System.Console.WriteLine("Do you want to sort another directory? (y/n)");
                    var sortAgain = System.Console.ReadKey();
                    if (sortAgain.KeyChar != 'y')
                    {
                        isRunning = false;
                    }

                    PrintOptions();
                }
                else
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine("Invalid selection.");
                }
            }            
        }
    }
}
