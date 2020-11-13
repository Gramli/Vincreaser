# Vincreaser
.NET Core console application for solution versioning. 

## Commands
* Commands: 
	* 	-type (.csproj, assemblyInfo)
	*   -increase
		* *major number (example: -increase major 1)
		* *minor number (example: -increase minor 1)
		* *patch number (example: -increase patch 1)
	*	-set version (example: -set 1.1.0.0)
	*   -path directory or file (example: -path C:\\git\MySolution\ -increase patch 1)
	*   -exclude [projectname, secondProjectName, ...] (example: -path C:\\git\MySolution\ -increase patch 1 -exclude[MySecondProject])