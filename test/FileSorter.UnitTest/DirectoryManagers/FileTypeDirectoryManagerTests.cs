using FileSorter.Business;
using FileSorter.Business.DirectoryManagers;
using NSubstitute;

namespace FileSorter.UnitTest.DirectoryManagers
{
    public sealed class FileTypeDirectoryManagerTests
    {
        private FileTypeDirectoryManager _directoryManager = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _directoryManager = new FileTypeDirectoryManager();
        }

        [TestCase("FileType", "", "Other")]
        [TestCase("FileType", ".jpg", "Images")]
        [TestCase("FileType", ".mp4", "Videos")]
        [TestCase("FileType", ".mp3", "Sounds")]
        [TestCase("FileType", ".pdf", "Documents")]
        [TestCase("FileType", ".zip", "Archive")]
        public void GetFolderDestination(string fileName, string extension, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.FullName.Returns(fileName);
            fileInfo.Extension.Returns(extension);

            var actual = _directoryManager.GetFolderDestination(string.Empty, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase("FileType", "FileType")]
        public void GetNewFileName(string fileName, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.FullName.Returns(fileName);

            var actual = _directoryManager.GetNewFileName(string.Empty, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}