namespace FileSorter.UnitTest.DirectoryManagers
{
    internal sealed class FileExtensionDirectoryManagerTests
    {
        private FileExtensionDirectoryManager _directoryManager = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _directoryManager = new FileExtensionDirectoryManager(new CrossPlatformPath());
        }

        [TestCase(".pdf", "", "pdf")]
        [TestCase(".PDF", "", "pdf")]
        [TestCase(".jpg", "Destination", "Destination/jpg")]
        public void GetFolderDestination(string extension, string destination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Extension.Returns(extension);

            var actual = _directoryManager.GetFolderDestination(destination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("FileNameA", "FileNameA", "", "FileNameA")]
        [TestCase("FileNameA.pdf", "FileNameA", "", "FileNameA")]
        [TestCase("FileNameA.pdf", "FileNameA.pdf", "", "FileNameA.pdf")]
        [TestCase("FileNameA", "FileNameA.pdf", "", "FileNameA.pdf")]
        [TestCase("FileNameB", "Source/FileNameB", "Destination/Books/FileNameB", "Destination/Books/FileNameB/FileNameB")]
        [TestCase("FileNameB.pdf", "Source/FileNameB", "Destination/Books/FileNameB", "Destination/Books/FileNameB/FileNameB")]
        [TestCase("FileNameB.pdf", "Source/FileNameB.pdf", "Destination/Books/FileNameB", "Destination/Books/FileNameB/FileNameB.pdf")]
        [TestCase("FileNameB", "Source/FileNameB.pdf", "Destination/Books/FileNameB", "Destination/Books/FileNameB/FileNameB.pdf")]
        public void GetNewFileName(string fileName, string fileFullName, string folderDestination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Name.Returns(fileName);
            fileInfo.FullName.Returns(fileFullName);

            var actual = _directoryManager.GetNewFileName(folderDestination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}