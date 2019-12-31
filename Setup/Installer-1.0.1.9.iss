; -- RedmiNote7Tool-Installer.iss --

#define MyAppName "RedmiNote7Tool"
#define MyAppVersion "1.0.1.9"
#define MyAppExeName "RedmiNote7Tool.exe"

[Setup]
AppName=RedmiNote7Tool
AppVersion=1.0.1.9
WizardStyle=modern
DefaultDirName={autopf}\RedmiNote7Tool
DefaultGroupName=RedmiNote7Tool
UninstallDisplayIcon={app}\2.ico
Compression=lzma2
SolidCompression=yes
OutputDir=C:\adb\
ChangesAssociations=yes
UserInfoPage=no
ArchitecturesAllowed=x64
ArchitecturesInstallIn64BitMode=x64
AppContact=Support
TouchDate=2019-12-28
OutputBaseFilename=RedmiNote7Tool_v1.0.1.9_Setup
InfoBeforeFile=changelog.txt

AppCopyright=Copyright (C) 2019 Franco28.
AppComments=A Basic Tool for Xiaomi Redmi Note 7 Lavender
AppPublisher=Franco28
AppPublisherURL=https://github.com/Franco28/RedmiNote7ToolC-#redmi-note-7-tool

BackColor=clBlue
BackColor2=clBlack

[Files]
Source: "2.ico"; DestDir: "{app}"
Source: "RedmiNote7Tool.exe.config"; DestDir: "{app}"
Source: "RedmiNote7Tool.exe"; DestDir: "{app}"
Source: "AndroidLib.dll"; DestDir: "{app}"

[Icons]
Name: "{group}\RedmiNote7Tool"; Filename: "{app}\RedmiNote7Tool.exe"
Name: {group}\RedmiNote7Tool; Filename: {app}\RedmiNote7Tool.exe; WorkingDir: {app}; IconFilename: {app}\2.ico; Comment: "RedmiNote7Tool"; 
Name: {commondesktop}\RedmiNote7Tool; Filename: {app}\RedmiNote7Tool.exe; WorkingDir: {app}; IconFilename: {app}\2.ico; Comment: "RedmiNote7Tool";

[UninstallDelete]
Type: files; Name: "C:\adb\*"; 
Type: filesandordirs; Name: "C:\adb"
Type: filesandordirs; Name: "C:\Program Files\RedmiNote7Tool"
