namespace FileSorter.UnitTest.DirectoryManagers
{
    internal sealed class DateTimeDirectoryManagerTests
    {
        private DateTimeDirectoryManager _directoryManager = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _directoryManager = new DateTimeDirectoryManager(new CrossPlatformPath());
        }

        [TestCase(2005, "", "2005")]
        [TestCase(1988, "Destination", "Destination/1988")]
        public void GetFolderDestination(int year, string destination, string expected)
        {
            var date = new DateTime(year, 1, 1);
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.LastWriteTime.Returns(date);

            var actual = _directoryManager.GetFolderDestination(destination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase(1988, 5, 7, "FileNameA", "FileNameA", ".pdf", "", "07 May 1988 000000 [FileNameA].pdf")]
        [TestCase(2023, 12, 31, "FileNameB", "FileNameB", ".pdf", "Destination", "Destination/31 Dec 2023 000000 [FileNameB].pdf")]
        [TestCase(2023, 12, 31, "FileNameB.pdf", "Source/FileNameB", ".pdf", "Destination", "Destination/31 Dec 2023 000000 [FileNameB].pdf")]
        [TestCase(2023, 12, 31, "FileNameB.pdf", "Source/FileNameB.pdf", ".pdf", "Destination", "Destination/31 Dec 2023 000000 [FileNameB].pdf")]
        [TestCase(2023, 12, 31, "FileNameB", "Source/FileNameB.pdf", ".pdf", "Destination", "Destination/31 Dec 2023 000000 [FileNameB].pdf")]
        public void GetNewFileName(int year, int month, int day, string fileName, string fileFullName, string extension, string folderDestination, string expected)
        {
            var date = new DateTime(year, month, day);
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.LastWriteTime.Returns(date);
            fileInfo.Name.Returns(fileName);
            fileInfo.FullName.Returns(fileFullName);
            fileInfo.Extension.Returns(extension);

            var actual = _directoryManager.GetNewFileName(folderDestination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}