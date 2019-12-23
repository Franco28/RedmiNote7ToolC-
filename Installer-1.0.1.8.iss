; -- RedmiNote7Tool-Installer.iss --

#define MyAppName "RedmiNote7Tool"
#define MyAppVersion "1.0.1.8"
#define MyAppExeName "RedmiNote7Tool.exe"

[Setup]
AppName=RedmiNote7Tool
AppVersion=1.0.1.8
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
TouchDate=2019-12-23
AppComments=Hey! Thanks for using this Basic Tool!
OutputBaseFilename=RedmiNote7Tool_v1.0.1.8_Setup
AppCopyright=Copyright (C) 2019 Franco28.

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
Type: filesandordirs; Name: "C:\adb"

[Code]
function NextButtonClick(CurPageID: Integer): Boolean;
var
  ResultCode: Integer;
begin
  if CurPageID = wpFinished then
  begin
    if Exec(
         ExpandConstant('{app}\RedmiNote7Tool.exe'), '', '', SW_SHOW, ewNoWait, ResultCode) then
    begin
      Log('Executed RedmiNote7Tool');
    end
      else
    begin
      MsgBox('Error executing RedmiNote7Tool - ' + SysErrorMessage(ResultCode), mbError, MB_OK);
    end;
  end;
  Result := True;
end;
