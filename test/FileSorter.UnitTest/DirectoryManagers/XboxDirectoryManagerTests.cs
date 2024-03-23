namespace FileSorter.UnitTest.DirectoryManagers
{
    internal sealed class XboxDirectoryManagerTests
    {
        private XboxDirectoryManager _directoryManager = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _directoryManager = new XboxDirectoryManager(new CrossPlatformPath());
        }

        [TestCase("FileA", ".jpg", "", "FileA/Screenshots")]
        [TestCase("GameA-FileA", ".jpg", "", "GameA/Screenshots")]
        [TestCase("GameA-FileA", ".JPG", "", "GameA/Screenshots")]
        [TestCase("GameA-FileB", ".mp4", "Files", "Files/GameA/Clips")]
        public void GetFolderDestination(string fileName, string extension, string destination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Name.Returns(fileName);
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