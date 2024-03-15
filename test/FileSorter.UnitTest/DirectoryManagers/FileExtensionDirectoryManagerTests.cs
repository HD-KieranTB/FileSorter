namespace FileSorter.UnitTest.DirectoryManagers
{
    internal sealed class FileExtensionDirectoryManagerTests
    {
        private FileExtensionDirectoryManager _directoryManager = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _directoryManager = new FileExtensionDirectoryManager();
        }

        [TestCase(".pdf", "", "pdf")]
        [TestCase(".PDF", "", "pdf")]
        [TestCase(".jpg", "Files", "Files\\jpg")]
        public void GetFolderDestination(string extension, string destination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Extension.Returns(extension);

            var actual = _directoryManager.GetFolderDestination(destination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("FileNameA", "", "FileNameA")]
        [TestCase("FileNameB", "Files\\pdf", "Files\\pdf\\FileNameB")]
        public void GetNewFileName(string fileName, string folderDestination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.FullName.Returns(fileName);

            var actual = _directoryManager.GetNewFileName(folderDestination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}