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

        [TestCase("Author - Book title", "Some/Other/Path/Author - Book title", "Files", "Files/Books/Author/Author - Book title")]
        [TestCase("Author - Book title", "Books/Author - Book title", "Files", "Files/Books/Author/Author - Book title")]
        [TestCase("Book title", "Books/Book title", "Files", "Files/Books/UnknownAuthor/Book title")]
        public void GetFolderDestination(string fileName, string fullFileName, string destination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Name.Returns(fileName);
            fileInfo.FullName.Returns(fullFileName);

            var actual = _directoryManager.GetFolderDestination(destination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("FileNameA", "FileNameA", "", "FileNameA")]
        [TestCase("FileNameB", "Books/FileNameB", "Files/Books/FileNameB", "Files/Books/FileNameB/FileNameB")]
        public void GetNewFileName(string fileName, string fullFileName, string folderDestination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Name.Returns(fileName);
            fileInfo.FullName.Returns(fullFileName);

            var actual = _directoryManager.GetNewFileName(folderDestination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}