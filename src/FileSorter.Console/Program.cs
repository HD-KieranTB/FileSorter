using FileSorter.Business;

Console.WriteLine("Starting...");

Console.WriteLine("Enter in the source directory.");
var source = Console.ReadLine();
Console.WriteLine("Enter in the destination directory.");
var destination = Console.ReadLine();

ArgumentException.ThrowIfNullOrEmpty(source);
ArgumentException.ThrowIfNullOrEmpty(destination);

var files = Directory.GetFiles(source, "*.*", SearchOption.AllDirectories);

FileDirectory.CreateDirectoryIfNew(destination);
var organiser = new Organiser(new FileExtensionDirectoryManager());
await organiser.Organise(files, destination);

Console.WriteLine("Completed.");
Console.ReadLine();