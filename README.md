# Vincreaser
.NET Core console application for solution versioning. Using commands you can init, increase, set, get project version. You can use Vincrease in Visual Studio events like pre-build, post-build, pre-publish etc. or in Git hooks.

 Actual version supports .csproj, assemblyInfo.cs, version.go files.

## Commands

**You have to always use -type, -path and one of the action commands (-increase, -set, -get, init), -exclude is not mandatory. Order of the commands is not important.**



*   -type (.csproj, assemblyInfo.cs, version.go)
*   -increase
	* major (example: -increase major)
	* minor (example: -increase minor)
	* build (example: -increase build)
	* revision (example: -increase revision)
*	-set version (example: -set 1.1.2.3)
*   -get
*   -init projectname
*   -path directory or file (example: -path C:\\git\MySolution\ -increase patch 1)
*   -exclude [projectname, secondProjectName, ...] (example: -path C:\\git\MySolution\ -increase patch 1 -exclude[MySecondProject])

### Examples
#### -incrase
```
//example
-type .csproj -increase build -path E:\GitHub\Vincreaser\Vincreaser\VincreaserApp
```
#### -set
```
//example
-set -type version.go -path Assets\version.go
```
#### -get
```
//example
-get -type version.go -path Assets\version.go
```
#### -init
```
//example
-path Assets\TestAssembleInfoDir -init testingProject -type assemblyInfo.cs
```


## Using
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

**pre-commit hook:**
1. Create two files in .git/hooks directory, one without extension, second as .bat file. Both name as pre-commit
![Visual Studio ](/Images/hooks.png)
2. Add to pre-commit file without extension this code:
```
#!/bin/sh
cmd.exe /c "E:\GitHub\Vincreaser\.git\hooks\pre-commit.bat" //run pre-commit.bat in cmd
git add . //add(stage) all changes to commit
exit 0
```
If you want to stage only edited files you can specify file name after git add command like `git add 'Vincreaser\VincreaserApp\VincreaserApp.csproj'`
3. Add to pre-commit.bat file this code:
```
//first part is path to installed Vincreaser and second are arguments
"E:\GitHub\Vincreaser\Vincreaser\VincreaserApp\bin\Debug\netcoreapp3.1\VincreaserApp.exe" "-type .csproj -increase build -path E:\GitHub\Vincreaser\Vincreaser\VincreaserApp"
```
Command run Vincreaser app with argument, which increase build part of version to all .csproj files in E:\GitHub\Vincreaser\Vincreaser\VincreaserApp directory.

**pre-push hook:**
1. Create two files in .git/hooks directory, one without extension, second as .bat file. Both name as pre-push
![Visual Studio ](/Images/hooks_prepush.png)
2. Add to pre-push file without extension this code:
```
#!/bin/sh
cmd.exe /c "E:\GitHub\Vincreaser\.git\hooks\pre-push.bat" //run pre-push.bat in cmd
git add 'Vincreaser\VincreaserApp\VincreaserApp.csproj' //add changed file by Vincreaser to commit
git add 'Vincreaser\VincreaserLib\VincreaserLib.csproj' //add changed file by Vincreaser to commit
git commit -m "pre-pust automatic commit for versioning" //commit changed files
exit 0
```
3. Add to pre-commit.bat file this code:
```
//first part is path to installed Vincreaser and second are arguments
"E:\GitHub\Vincreaser\Vincreaser\VincreaserApp\bin\Debug\netcoreapp3.1\VincreaserApp.exe" "-type .csproj -increase build -path E:\GitHub\Vincreaser\Vincreaser\VincreaserApp" "-type .csproj -increase build -path E:\GitHub\Vincreaser\Vincreaser\VincreaserLib"
```
Command run Vincreaser app with argument, which increase build part of version to all .csproj files in E:\GitHub\Vincreaser\Vincreaser\VincreaserApp and E:\GitHub\Vincreaser\Vincreaser\VincreaserLib directories.
