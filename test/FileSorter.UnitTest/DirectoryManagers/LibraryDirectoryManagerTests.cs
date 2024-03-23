namespace FileSorter.UnitTest.DirectoryManagers
{
    internal sealed class LibraryDirectoryManagerTests
    {
        private LibraryDirectoryManager _directoryManager = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _directoryManager = new LibraryDirectoryManager(new CrossPlatformPath());
        }

        [TestCase("Author - Book title", "Source/Author - Book title", "Destination", "Destination/Books/Author/Author - Book title")]
        [TestCase("Author - Book title.pdf", "Source/Author - Book title", "Destination", "Destination/Books/Author/Author - Book title")]
        [TestCase("Author - Book title.pdf", "Source/Author - Book title.pdf", "Destination", "Destination/Books/Author/Author - Book title")]
        [TestCase("Author - Book title", "Source/Author - Book title.pdf", "Destination", "Destination/Books/Author/Author - Book title")]
        [TestCase("Book title", "Source/Book title", "Destination", "Destination/Books/UnknownAuthor/Book title")]
        [TestCase("Book title.pdf", "Source/Book title", "Destination", "Destination/Books/UnknownAuthor/Book title")]
        [TestCase("Book title.pdf", "Source/Book title.pdf", "Destination", "Destination/Books/UnknownAuthor/Book title")]
        [TestCase("Book title", "Source/Book title.pdf", "Destination", "Destination/Books/UnknownAuthor/Book title")]
        public void GetFolderDestination(string fileName, string fullFileName, string destination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Name.Returns(fileName);
            fileInfo.FullName.Returns(fullFileName);

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