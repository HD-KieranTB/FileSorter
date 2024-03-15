namespace FileSorter.UnitTest.DirectoryManagers
{
    internal sealed class XboxDirectoryManagerTests
    {
        private XboxDirectoryManager _directoryManager = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _directoryManager = new XboxDirectoryManager();
        }

        [TestCase("FileA", ".jpg", "", "FileA\\Screenshots")]
        [TestCase("GameA-FileA", ".jpg", "", "GameA\\Screenshots")]
        [TestCase("GameA-FileA", ".JPG", "", "GameA\\Screenshots")]
        [TestCase("GameA-FileB", ".mp4", "Files", "Files\\GameA\\Clips")]
        public void GetFolderDestination(string fileName, string extension, string destination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Name.Returns(fileName);
            fileInfo.Extension.Returns(extension);

            var actual = _directoryManager.GetFolderDestination(destination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("FileNameA", "", "FileNameA")]
        [TestCase("FileNameB", "Files\\Screenshots", "Files\\Screenshots\\FileNameB")]
        public void GetNewFileName(string fileName, string folderDestination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.FullName.Returns(fileName);

            var actual = _directoryManager.GetNewFileName(folderDestination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}