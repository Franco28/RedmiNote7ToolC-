; -- RedmiNote7Tool-Installer.iss  (C) 2019 - 2020 --
; -- This is only for RN7 Tool --

#define MyAppName "RedmiNote7Tool"
#define MyAppVersion "1.0.2.4"
#define MyAppExeName "RedmiNote7Tool.exe"

[Setup]
AppName=RedmiNote7Tool
AppVersion=1.0.2.4
ArchitecturesAllowed=x64
ArchitecturesInstallIn64BitMode=x64
AppContact=Support
AppCopyright=Copyright (C) 2019 - 2020 Franco28.
AppComments=A Basic Tool for Xiaomi Redmi Note 7 Lavender
AppPublisher=Franco28
AppPublisherURL=https://github.com/Franco28/RedmiNote7ToolC-#redmi-note-7-tool
BackColor=clBlue
BackColor2=clBlack
ChangesAssociations=yes
Compression=lzma2/ultra64
CompressionThreads=2
DefaultDirName={autopf}\RedmiNote7Tool
DefaultGroupName=RedmiNote7Tool
InternalCompressLevel=ultra
InfoBeforeFile=changelog.txt
OutputDir=C:\adb\
OutputBaseFilename=RedmiNote7Tool_v1.0.2.4_Setup
SolidCompression=yes
TouchDate=2020-01-29
UninstallDisplayIcon={app}\2.ico
UserInfoPage=no
WizardStyle=modern
WizardSmallImageFile=small_ico.bmp
WizardImageFile=large_ico.bmp 

[Files]
Source: "2.ico"; DestDir: "{app}"
Source: "RedmiNote7Tool.exe.config"; DestDir: "{app}"
Source: "RedmiNote7Tool.exe.manifest"; DestDir: "{app}"
Source: "RedmiNote7Tool.exe"; DestDir: "{app}"
Source: "RedmiNote7Tool.application"; DestDir: "{app}"
Source: "AndroidLib.dll"; DestDir: "{app}"
Source: "MiUSB.dll"; DestDir: "{app}"
Source: "ToolEngine.dll"; DestDir: "{app}"
Source: "es\*"; DestDir: "{app}\es\"
Source: "en\*"; DestDir: "{app}\en\"

[Dirs]
Name: "{autopf}\RedmiNote7Tool\es"
Name: "{autopf}\RedmiNote7Tool\en"

[Icons]
Name: "{group}\RedmiNote7Tool"; Filename: "{app}\RedmiNote7Tool.exe"
Name: {group}\RedmiNote7Tool; Filename: {app}\RedmiNote7Tool.exe; WorkingDir: {app}; IconFilename: {app}\2.ico; Comment: "RedmiNote7Tool"; 
Name: {commondesktop}\RedmiNote7Tool; Filename: {app}\RedmiNote7Tool.exe; WorkingDir: {app}; IconFilename: {app}\2.ico; Comment: "RedmiNote7Tool";

[UninstallDelete]
Type: files; Name: "C:\adb\*"; 
Type: filesandordirs; Name: "C:\adb"
Type: filesandordirs; Name: "C:\Program Files\RedmiNote7Tool"
