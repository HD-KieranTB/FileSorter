<h1 align="center">FileSorter</h1>
<h3 align="center">The Free Software File Sorter</h3>

FileSorter provides various strategies for automatically sorting files

<h4 align="center">Current use cases</h3>

Consider the following directory and files:

-> Photos
--> AFileOne.jpg (12/24/2023)
-> BFileTwo.jpg (11/14/2023)
-> BFileThree.jpg (11/20/2022)

Sort the files by the date and time they were last edited using the DateTimeDirectoryManager.

-> 2022
--> 20 Nov 2022 [BFileThree].jpg
-> 2023
--> 14 Nov 2023 [BFileTwo].jpg
--> 24 Dec 2023 [AFileOne].jpg

Sort the files into alphabetical folders using the AlphabetDirectoryManager.

-> A
--> AFileOne.jpg
-> B
--> BFileThree.jpg
--> BFileTwo.jpg

Consider the following directory and files:

-> Xbox Screenshots
--> Battlefield™ 1-2016_10_26-13_59_27.jpg
--> ARK_Survival Evolved-2016_01_16-21_19_42
-> Xbox Game DVR
--> Battlefield™ 1-2016_10_26-13_59_27

Sort files originating from xbox using the XboxDirectoryManager.

-> Battlefield
--> Clips
---> Battlefield™ 1-2016_10_26-13_59_27
--> Screenshots
---> Battlefield™ 1-2016_10_26-13_59_27.jpg
-> ARK Survival Evolved
--> Screenshots
---> ARK_Survival Evolved-2016_01_16-21_19_42