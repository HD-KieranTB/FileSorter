<h1 align="center">File Sorter</h1>
<h3 align="center">The Free Cross-Platform File Sorter</h3>

This file sorter provides various strategies for automatically sorting files. The original structure of the files is maintained as the sorter works by <b>copying</b> files from a source directory to a destination directory, provided by the user.

> [!IMPORTANT]
> Some sorting strategies may rely on file naming conventions, such as xbox and book files.

<h3>Table of Contents</h3>

- [Sort by Date](#date)
- [Sort by Alphabet](#alphabet)
- [Sort by File Type](#filetype)
- [Sort by File Extension](#fileextension)
- [Sort Xbox Files](#xbox)
- [Sort Books](#books)

<h3 align="center">Current Strategies</h3>

Consider the following directory and files:

```bash
 Files
  ├── Photos
  │   └── AFileOne.jpg (12/24/2023)
  │ 
  ├── BFileTwo.mp3 (11/14/2023)
  │ 
  └── BFileThree.pdf (11/20/2022)
```
<h3><a name="date">Sort by Date</a></h3>

<strong>Sort the files by the date and time they were last edited using the DateTimeDirectoryManager.</strong>

```bash
  Files
  ├── 2022
  │   └── 20 Nov 2022 [BFileThree].pdf
  │ 
  └── 2023
      ├── 14 Nov 2023 [BFileTwo].mp3 
      └── 24 Dec 2023 [AFileOne].jpg        
```

<h3><a name="alphabet">Sort by Alphabet</a></h3>

<strong>Sort the files into alphabetical folders using the AlphabetDirectoryManager.</strong>

```bash
  Files
  ├── A
  │   └── AFileOne.jpg
  │ 
  └── B
      ├── BFileThree.pdf
      └── BFileTwo.mp3   
```

<h3><a name="filetype">Sort by File Type</a></h3>

<strong>Sort the files into folders by category using the FileTypeDirectoryManager.</strong>

```bash
  Files
  ├── Images
  │   └── AFileOne.jpg
  │ 
  ├── Sounds
  │   └── BFileTwo.mp3   
  │ 
  └── Documents
      └── BFileThree.pdf
```

<h3><a name="fileextension">Sort by File Extension</a></h3>

<strong>Sort the files into folders by extension type using the FileExtensionDirectoryManager.</strong>

```bash
  Files
  ├── jpg
  │   └── AFileOne.jpg
  │ 
  ├── mp3
  │   └── BFileTwo.mp3   
  │ 
  └── pdf
      └── BFileThree.pdf
```

<h3><a name="xbox">Sort Xbox Files</a></h3>

Consider the following directory and files:

```bash
  Files
  ├── Xbox Game DVR
  │   └── Battlefield™ 1-2016_10_26-13_59_27.mp4
  │ 
  └── Xbox Screenshots
      ├── Battlefield™ 1-2016_10_26-13_59_27.jpg
      └── ARK_Survival Evolved-2016_01_16-21_19_42.jpg  
```

<strong>Sort files originating from xbox using the XboxDirectoryManager.</strong>

```bash
Files
  ├── Battlefield
  │   ├── Clips
  │   │   └── Battlefield™ 1-2016_10_26-13_59_27.mp4
  │   └── Screenshots
  │       └── Battlefield™ 1-2016_10_26-13_59_27.jpg
  │ 
  └── ARK Survival Evolved
      └── Screenshots
          └── ARK_Survival Evolved-2016_01_16-21_19_42.jpg
```

<h3><a name="books">Sort Books</a></h3>

Consider the following directory and files:

```bash
  Files
  ├── Docs
  │   ├── Author A - Title A.pdf
  │   └── Title C.pdf
  │ 
  └── Research
      ├── Author B - Title A.pdf
      ├── Author B - Title A.png
      └── Author B - Title B.pdf
```

<strong>Sort books into folders by author using the LibraryDirectoryManager.</strong>

```bash
Files
  └── Books
       ├── Author A
       │   └── Author A - Title A
       │	└── Author A - Title A.pdf
       │       
       ├── Author B
       │    ├── Author B - Title A
       │    │	├── Author B - Title A.pdf
       │    │	└── Author B - Title A.png
       │    └── Author B - Title B
       │	└── Author B - Title B.pdf
       │
       └── Unknown Author
           └── Title C
		└── Title C.pdf

```
