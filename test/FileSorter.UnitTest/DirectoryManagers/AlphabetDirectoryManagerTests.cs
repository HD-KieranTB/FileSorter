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
        [TestCase("Alphabet", "Files", "Files/A")]
        [TestCase("alphabet", "Files", "Files/A")]
        [TestCase("*abc", "Files", "Files/Other")]
        [TestCase("_", "Files", "Files/Other")]
        [TestCase("999", "Files", "Files/Other")]
        public void GetFolderDestination(string fileName, string destination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Name.Returns(fileName);

            var actual = _directoryManager.GetFolderDestination(destination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("Alphabet", "", "Alphabet 01 Jan 0001 000000")]
        [TestCase("Alphabet", "Files", "Files/Alphabet 01 Jan 0001 000000")]
        public void GetNewFileName(string fileName, string folderDestination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.FullName.Returns(fileName);

            var actual = _directoryManager.GetNewFileName(folderDestination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}