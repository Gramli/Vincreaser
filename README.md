# Vincreaser
.NET Core console application for solution versioning. 

## Commands
* Commands: 
	* 	-type (.csproj, assemblyInfo.cs, version.go)
	*   -increase
		* major (example: -increase major)
		* minor (example: -increase minor)
		* build (example: -increase build)
		* revision (example: -increase revision)
	*	-set version (example: -set 1.1.2.3)
	*   -path directory or file (example: -path C:\\git\MySolution\ -increase patch 1)
	*   -exclude [projectname, secondProjectName, ...] (example: -path C:\\git\MySolution\ -increase patch 1 -exclude[MySecondProject])