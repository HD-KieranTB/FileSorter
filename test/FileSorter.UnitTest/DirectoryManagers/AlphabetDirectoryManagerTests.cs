namespace FileSorter.UnitTest.DirectoryManagers
{
    internal sealed class AlphabetDirectoryManagerTests
    {
        private AlphabetDirectoryManager _directoryManager = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _directoryManager = new AlphabetDirectoryManager(new CrossPlatformPath());
        }

        [TestCase("Alphabet", "", "A")]
        [TestCase("alphabet", "", "A")]
        [TestCase("*abc", "", "Other")]
        [TestCase("_", "", "Other")]
        [TestCase("999", "", "Other")]
        [TestCase("Alphabet", "Destination", "Destination/A")]
        [TestCase("alphabet", "Destination", "Destination/A")]
        [TestCase("alphabet.pdf", "Destination", "Destination/A")]
        [TestCase("*abc", "Destination", "Destination/Other")]
        [TestCase("_", "Destination", "Destination/Other")]
        [TestCase("999", "Destination", "Destination/Other")]
        public void GetFolderDestination(string fileName, string destination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Name.Returns(fileName);

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