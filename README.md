# Vincreaser
.NET Core console application for solution versioning. 

## Commands
	*   -type (.csproj, assemblyInfo.cs, version.go)
	*   -increase
		* major (example: -increase major)
		* minor (example: -increase minor)
		* build (example: -increase build)
		* revision (example: -increase revision)
	*	-set version (example: -set 1.1.2.3)
	*   -get
	*   -path directory or file (example: -path C:\\git\MySolution\ -increase patch 1)
	*   -exclude [projectname, secondProjectName, ...] (example: -path C:\\git\MySolution\ -increase patch 1 -exclude[MySecondProject])

## Examples
### Visual Studio
You can simply use Vincreaser application in VS build events:

![Visual Studio ](/Images/vs_postbuild.png)

And use command like this:
```
//first part is path to installed Vincreaser and second are arguments
"C:\Program Files (x86)\Vincreaser\VincreaserApp.exe" "-type .csproj -increase revision -path E:\GitHub\Vincreaser\Vincreaser\VincreaserApp"
```

### Git hooks
You can use Vincreaser in any git hook and run it using .bat file.

** pre-commit hook: **
1. Create two files in .git/hooks directory, one without extension, second as .bat file. Both name as pre-commit
![Visual Studio ](/Images/hooks.png)
2. Add to pre-commit file without extension this code:
```
#!/bin/sh
cmd.exe /c "E:\GitHub\Vincreaser\.git\hooks\pre-commit.bat"
git add .
exit 0
```
Commands run .bat file, stage all edited files to commit and exit. If you want to stage only edited files you can specify file name after git add command like `git add E:\GitHub\Vincreaser\Vincreaser\VincreaserApp/VincreaserApp.csproj`
3. Add to pre-commit.bat file this code:
```
//first part is path to installed Vincreaser and second are arguments
"E:\GitHub\Vincreaser\Vincreaser\VincreaserApp\bin\Debug\netcoreapp3.1\VincreaserApp.exe" "-type .csproj -increase build -path E:\GitHub\Vincreaser\Vincreaser\VincreaserApp"
```
Command run Vincreaser app with argument, you can use more arguments of course.