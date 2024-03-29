﻿namespace FileSorter.Business
{
    public static class ExtensionTypes
    {
        public static readonly string[] IMAGE_EXTENSIONS =
               [".png",
                ".jpg",
                ".jpeg",
                ".jpe",
                ".jif",
                ".jfif",
                ".jfi",
                ".gif",
                ".webp",
                ".tiff",
                ".jfif",
                ".jfi",
                ".gif",
                ".webp",
                ".tiff",
                ".tif",
                ".psd",
                ".raw",
                ".arw",
                ".cr2",
                ".nrw",
                ".k25",
                ".bmp",
                ".dip",
                ".heif",
                ".heic",
                ".ind",
                ".indd",
                ".indt",
                ".jp2",
                ".j2k",
                ".jpf",
                ".jpx",
                ".jpm",
                ".mj2",
                ".svg",
                ".svgz",
                ".ai",
                ".eps"];
        public static readonly string[] VIDEO_EXTENSIONS =
               [".webm",
                ".mpg",
                ".mp2",
                ".mpeg",
                ".mpe",
                ".mpv",
                ".ogg",
                ".mp4",
                ".m4p",
                ".m4v",
                ".avi",
                ".wmv",
                ".mov",
                ".qt",
                ".flv",
                ".swf",
                ".avchd"];
        public static readonly string[] SOUND_EXTENSIONS =
               [".mp3", 
                ".wav",
                ".flac"];
        public static readonly string[] DOCUMENT_EXTENSIONS =
               [".doc", 
                ".docx",
                ".html",
                ".htm", 
                ".odt", 
                ".pdf", 
                ".xls", 
                ".xlsx", 
                ".ods", 
                ".ppt",
                ".pptx", 
                ".txt"];
        public static readonly string[] ARCHIVE_EXTENSIONS =
               [".zip",
                ".tar",
                ".7z"];
    }
}