using FileSorter.Business;
using FileSorter.Business.DirectoryManagers;
using NSubstitute;

namespace FileSorter.UnitTest.DirectoryManagers
{
    public sealed class FileExtensionDirectoryManagerTests
    {
        private FileExtensionDirectoryManager _directoryManager = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _directoryManager = new FileExtensionDirectoryManager();
        }

        [TestCase(".pdf", "", "pdf")]
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
        public void GetNewFileName(string fileName, string destination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.FullName.Returns(fileName);

            var actual = _directoryManager.GetNewFileName(destination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}