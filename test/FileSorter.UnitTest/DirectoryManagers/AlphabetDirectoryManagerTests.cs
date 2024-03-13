using FileSorter.Business;
using FileSorter.Business.DirectoryManagers;
using NSubstitute;

namespace FileSorter.UnitTest.DirectoryManagers
{
    public sealed class AlphabetDirectoryManagerTests
    {
        private AlphabetDirectoryManager _directoryManager = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _directoryManager = new AlphabetDirectoryManager();
        }

        [TestCase("Alphabet", "A")]
        [TestCase("alphabet", "A")]
        [TestCase("*abc", "Other")]
        [TestCase("_", "Other")]
        [TestCase("999", "Other")]
        public void GetFolderDestination(string fileName, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Name.Returns(fileName);

            var actual = _directoryManager.GetFolderDestination(string.Empty, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("Alphabet", "Alphabet 01 Jan 0001 000000")]
        public void GetNewFileName(string fileName, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.FullName.Returns(fileName);

            var actual = _directoryManager.GetNewFileName(string.Empty, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}