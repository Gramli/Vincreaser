# Vincreaser
.NET Core console application for solution versioning. 

## Commands
* Commands: 
	* 	-type (.csproj, assemblyInfo.cs, version.go)
	*   -increase
		* *major number (example: -increase major 1)
		* *minor number (example: -increase minor 1)
		* *build number (example: -increase build 1)
		* *revision number (example: -increase revision 1)
	*	-set version (example: -set 1.1.0.0)
	*   -path directory or file (example: -path C:\\git\MySolution\ -increase patch 1)
	*   -exclude [projectname, secondProjectName, ...] (example: -path C:\\git\MySolution\ -increase patch 1 -exclude[MySecondProject])