<h1 align="center">FileSorter</h1>
<h3 align="center">The Free Software File Sorter</h3>

FileSorter provides various strategies for automatically sorting files

<h4 align="center">Current use cases</h3>

Consider the following directory and files:

 Files
  ├── Photos
  │   └── AFileOne.jpg (12/24/2023)
  │ 
  ├── BFileTwo.mp3 (11/14/2023)
  │ 
  └── BFileThree.pdf (11/20/2022)

Sort the files by the date and time they were last edited using the DateTimeDirectoryManager.

  Files
  ├── 2022
  │   └── 20 Nov 2022 [BFileThree].pdf
  │ 
  └── 2023
      ├── 14 Nov 2023 [BFileTwo].mp3 
      └── 24 Dec 2023 [AFileOne].jpg        

Sort the files into alphabetical folders using the AlphabetDirectoryManager.

  Files
  ├── A
  │   └── AFileOne.jpg
  │ 
  └── B
      ├── BFileThree.pdf
      └── BFileTwo.mp3   

Consider the following directory and files:

  Files
  ├── Xbox Game DVR
  │   └── Battlefield™ 1-2016_10_26-13_59_27.mp4
  │ 
  └── Xbox Screenshots
      ├── Battlefield™ 1-2016_10_26-13_59_27.jpg
      └── ARK_Survival Evolved-2016_01_16-21_19_42.jpg  

Sort files originating from xbox using the XboxDirectoryManager.

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