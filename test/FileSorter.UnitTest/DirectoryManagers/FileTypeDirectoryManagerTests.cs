namespace FileSorter.UnitTest.DirectoryManagers
{
    internal sealed class FileTypeDirectoryManagerTests
    {
        private FileTypeDirectoryManager _directoryManager = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _directoryManager = new FileTypeDirectoryManager();
        }

        [TestCase("FileType", "", "", "Other")]
        [TestCase("FileType", ".jpg", "", "Images")]
        [TestCase("FileType", ".mp4", "", "Videos")]
        [TestCase("FileType", ".mp3", "", "Sounds")]
        [TestCase("FileType", ".pdf", "", "Documents")]
        [TestCase("FileType", ".zip", "", "Archive")]
        [TestCase("FileType", ".ZIP", "", "Archive")]
        [TestCase("FileType", "", "Files", "Files\\Other")]
        [TestCase("FileType", ".jpg", "Files", "Files\\Images")]
        [TestCase("FileType", ".mp4", "Files", "Files\\Videos")]
        [TestCase("FileType", ".mp3", "Files", "Files\\Sounds")]
        [TestCase("FileType", ".pdf", "Files", "Files\\Documents")]
        [TestCase("FileType", ".zip", "Files", "Files\\Archive")]
        [TestCase("FileType", ".ZIP", "Files", "Files\\Archive")]
        public void GetFolderDestination(string fileName, string extension, string destination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.FullName.Returns(fileName);
            fileInfo.Extension.Returns(extension);

            var actual = _directoryManager.GetFolderDestination(destination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("FileType", "", "FileType")]
        [TestCase("FileType", "Files", "Files\\FileType")]
        public void GetNewFileName(string fileName, string folderDestination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.FullName.Returns(fileName);

            var actual = _directoryManager.GetNewFileName(folderDestination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}