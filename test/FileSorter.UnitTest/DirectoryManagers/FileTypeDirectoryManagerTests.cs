namespace FileSorter.UnitTest.DirectoryManagers
{
    internal sealed class FileTypeDirectoryManagerTests
    {
        private FileTypeDirectoryManager _directoryManager = null!;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _directoryManager = new FileTypeDirectoryManager(new CrossPlatformPath());
        }

        [TestCase("FileName", "", "", "Other")]
        [TestCase("FileName", ".jpg", "", "Images")]
        [TestCase("FileName", ".mp4", "", "Videos")]
        [TestCase("FileName", ".mp3", "", "Sounds")]
        [TestCase("FileName", ".pdf", "", "Documents")]
        [TestCase("FileName", ".zip", "", "Archive")]
        [TestCase("FileName", ".ZIP", "", "Archive")]
        [TestCase("FileName", "", "Destination", "Destination/Other")]
        [TestCase("FileName", ".jpg", "Destination", "Destination/Images")]
        [TestCase("FileName", ".mp4", "Destination", "Destination/Videos")]
        [TestCase("FileName", ".mp3", "Destination", "Destination/Sounds")]
        [TestCase("FileName", ".pdf", "Destination", "Destination/Documents")]
        [TestCase("FileName", ".zip", "Destination", "Destination/Archive")]
        [TestCase("FileName", ".ZIP", "Destination", "Destination/Archive")]
        [TestCase("FileName", ".ZIP", "Destination", "Destination/Archive")]
        [TestCase("FileName.zip", ".ZIP", "Destination", "Destination/Archive")]
        public void GetFolderDestination(string fileName, string extension, string destination, string expected)
        {
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.FullName.Returns(fileName);
            fileInfo.Extension.Returns(extension);

            var actual = _directoryManager.GetFolderDestination(destination, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetFolderDestination_Images([ValueSource(nameof(GetImageExtensions))] string imageExtension)
        {
            var expected = "Images";
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Extension.Returns(imageExtension);

            var actual = _directoryManager.GetFolderDestination(string.Empty, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        private static string[] GetImageExtensions()
        {
            return ExtensionTypes.IMAGE_EXTENSIONS;
        }

        [Test]
        public void GetFolderDestination_Videos([ValueSource(nameof(GetVideoExtensions))] string imageExtension)
        {
            var expected = "Videos";
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Extension.Returns(imageExtension);

            var actual = _directoryManager.GetFolderDestination(string.Empty, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        private static string[] GetVideoExtensions()
        {
            return ExtensionTypes.VIDEO_EXTENSIONS;
        }

        [Test]
        public void GetFolderDestination_Sounds([ValueSource(nameof(GetSoundExtensions))] string imageExtension)
        {
            var expected = "Sounds";
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Extension.Returns(imageExtension);

            var actual = _directoryManager.GetFolderDestination(string.Empty, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        private static string[] GetSoundExtensions()
        {
            return ExtensionTypes.SOUND_EXTENSIONS;
        }

        [Test]
        public void GetFolderDestination_Documents([ValueSource(nameof(GetDocumentExtensions))] string imageExtension)
        {
            var expected = "Documents";
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Extension.Returns(imageExtension);

            var actual = _directoryManager.GetFolderDestination(string.Empty, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        private static string[] GetDocumentExtensions()
        {
            return ExtensionTypes.DOCUMENT_EXTENSIONS;
        }

        [Test]
        public void GetFolderDestination_Archive([ValueSource(nameof(GetArchiveExtensions))] string imageExtension)
        {
            var expected = "Archive";
            var fileInfo = Substitute.For<IReadonlyFileInfo>();
            fileInfo.Extension.Returns(imageExtension);

            var actual = _directoryManager.GetFolderDestination(string.Empty, fileInfo);

            Assert.That(actual, Is.EqualTo(expected));
        }

        private static string[] GetArchiveExtensions()
        {
            return ExtensionTypes.ARCHIVE_EXTENSIONS;
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