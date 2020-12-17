# Dialog Name
Name "Vincreaser"
# name the installer
OutFile "VincreaserInstaller.exe"
# Dialog Text
DirText "Vincreaser Installer. It will install all needed files and directories to use Vincreaser."

# define the directory to install to, the desktop in this case as specified  
InstallDir $PROGRAMFILES\Vincreaser

# default section start; every NSIS script has at least one section.
Section "Install"

# define the output path for this file
SetOutPath $INSTDIR

# create the uninstaller
WriteUninstaller "$INSTDIR\VincreaserUninstaller.exe"

CreateShortCut "$DESKTOP\Vincreaser.lnk" "$INSTDIR\VincreaserApp.exe"
CreateShortCut "$SMPROGRAMS\Vincreaser.lnk" "$INSTDIR\VincreaserApp.exe"

WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Vincreaser" \
                 "DisplayName" "Vincreaser -- Console Application for project versioning"
WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Vincreaser" \
                 "UninstallString" "$\"$INSTDIR\VincreaserUninstaller.exe$\""
 
# define what to install and place it in the output path
File /r \
/x "*.pdb" \
"E:\GitHub\Vincreaser\Vincreaser\VincreaserApp\bin\publish\win-x64\*.*"
 
# default section end
SectionEnd
 
# create a section to define what the uninstaller does.
# the section will always be named "Uninstall"
Section "Uninstall"
 
# Always delete uninstaller first
Delete $INSTDIR\VincreaserUninstaller.exe
Delete "$DESKTOP\Vincreaser.lnk"
Delete "$SMPROGRAMS\Vincreaser.lnk"
DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Vincreaser"
Delete $INSTDIR\*.*
 
# Delete the directory
RMDir /r $INSTDIR
SectionEnd