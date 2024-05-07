This program is an update to:
* Rex 'SaintPeter' Schrader's mapper2 and log_cleaner Perl scripts
 * Tacoman's ZoneRect Calculator.

This program simplifies and automates several of the tasks required to make the "lines" portion of an EQ2MAP.

The original tools are described here: https://maps.eq2interface.com/index.php?action=maptutorial&page=2

This project's home page is here: https://github.com/jeffjl74/EQ2MapTools

## Mapper2 Tab
![Mapper2](images/mapper2.png)

The mapper2 and log_cleaner functions are practically line-for-line conversions of the original Perl scripts to C#.
* C# is fixed so it properly recognizes color commands (fixed to only processes occurrences of the word "color" when it's an emote. And to recognize /em color as "set to black", which didn't work in the Perl script).
* The *Map Level* is optional, e.g. if there is only one level.
* The splitting by elevation into Inkscape groups works differently even though the C# looks like it should do the same thing the Perl script does. But the C# code result is logical, so I'm going with that. e.g. if you provide 2 numbers, you get 3 groups based upon the average elevation of a line:
	* -infinity to #1,
	* #1 to #2,
	* #2 to +infinity

The mapper tool adds some extra features:
* The button at the end of the *Base map name* box scans the *Input Log File* for map style names. If any are found, choosing one from the menu sets that as the *Base map name*.
* The *Build new mapper file from Input Log File* option is the same functionality as the old Mapper2 batch file (mapper2 and log_cleaner) except that the SVG file is built from the "clean" mapper file instead of directly from the EQII log file.
* The *Append Input Log File mapping lines to existing mapper file* option provides a means to gather mapping lines from different EQII log files into one mapper file. For example, if you collected some /loc data for the same map on more than one character. Or you collected some last week, and some more this week, and they are in different EQII log files.
* The *Use existing mapper file as is* option does not modify the mapper file when the [Run] button is pressed. Useful if you have hand-edited the mapper file.
* Two launch options are provided. I find it quicker to use a browser to view the SVG file while I'm still collecting and checking /loc data. Then use Inkscape when I'm ready to start editing.

## Zone Rect Tab
![Zone Rect](images/zonerect.png)
The major difference in the Zone Rect calculator is that this version can read the SVG file to extract and calculate the data for all the boxes. Pressing the Mapper2 tab [Run] button automatically calculates a zone rect from the generated SVG file. The [Open SVG...] button can also open a file generated by Mapper2 or an Inkscape-edited Mapper2 file.

The [Calculate] button is just like Tacoman's [Calculate] button. The information in the edit boxes is used to create the zonerect.

To calculate a zone rect directly from an SVG via the [Run] or [Open SVG...] button:
* Set the *Map Image Size* prior to using the [Run] or [Open SVG...] button.
	* The *In Game /loc Coordinates* are extracted directly from the *UL:* and *LR:* values in the SVG file.
	* The *Map crosshair coordinates* are calculated:
		* They are frequently off by a pixel or so (I can't figure out why).
		* The program picks a scaling factor to fit the SVG crosshairs into the Map Image Size and calculate the crosshair locations.  This is a suggestion as to how to scale the image to the map size when importing it into your image processing software.
		* It adjusts the width so that the height is the map height. Or it adjusts the height so the width is the map width. The "less than the map size" dimension is displayed with a green background. Entering either of the numbers in your image processing software scaling factors should result in both numbers matching the tool's numbers.
* Whether you use the suggested scale, or set your own, you should verify the crosshair locations in your image processing software and recalculate the zone rect if necessary.

Or you could hand enter the appropriate values and use the [Calculate] button.

The ZoneRect copy is also a bit differnt from Tacoman's copy in that the entire XML attribute for the MapStyles file is copied to the clipboard by the [Copy] button. The dropdown arrow on the [Copy] button also allows adding the "heightmin" and "heightmax" attributes to the copy if they were obtained from the SVG file.

## Map Loc Tab
![Map Loc](images/maploc.png)
Pressing the [Paste] button on the Map Location Calculator will paste the *In Game /loc coordinates* from the clipboard when set by the */loc clipboard* command in game.

The *ZoneRect* can be
* manually entered (4 numbers separated by space and or comma)
* copied from the Zone Rect tab by pressing the little clipboard button at the end
* set from a mapstyles file

To use a mapstyles file, browse to it in your game UI folder using the 3 dots button. You would typically pick the *core_mapstyles.xml* or *_User_MapStyles.xml* file. Then choose a map name from the dropdown list. Check the box to automatically load that file when the program starts.

Auto-complete is on for the Map Style combobox, but a match has to start matching with the first character (e.g. if looking for "Darkpaw Dugout", you have to start typing "darK", not "dug" to get a match). And the auto-complete dropdown will probably be too narrow. It can be resized by grabbing the resize handle at its lower right.

## Line Index Tab
![Line Index](images/lineindex.png)
The [Run] button on the Mapper2 tab also generates a cross reference between the mapper text file and the SVG file. The index is displayed on the Line Index tab. Double-clicking a line header (the leftmost column) opens the mapper text file in Notepad++ (https://notepad-plus-plus.org/) and positions the file at the "start new map line" for that SVG path.

When editing the file in Inkscape, the path names will match the *SVG line id* in the index. So if you wanted to, for example, remove a duplicate line from the mapper file, or change its color, you can identify the path name in Inkscape, jump to it in Notepad++ via the EQ2MAP Tool, and edit the mapper file. You would then want to select the *Use existing mapper file as is* on the Mapper2 tab to keep from overwriting your change with lines from the EQII log file. 

Of course, if you do add or delete something in the mapper file, all of the index entries below that change will be out of date until you [Run] again. So if you're making several changes it's probably quickest to start at the highest line number and work your way up the list.

The index is not generated if the *group by elevations* option is used because the SVG lines are rearranged out of order from the log file. It's easy enough to make a run without grouping by elevation if you want an index.

