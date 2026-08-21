#define MyAppName "Password Manager"
#define MyAppVersion "1.0.0"
#define MyAppPublisher "Password Manager"
#define MyAppExeName "PasswordManager.exe"

[Setup]
AppId={{18DEBAFC-FE40-431A-92D7-5E24FE602324}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}

DefaultDirName={autopf}\PasswordManager
DefaultGroupName=Password Manager

OutputDir=..\artifacts\installer
OutputBaseFilename=PasswordManager-Setup-{#MyAppVersion}

Compression=lzma
SolidCompression=yes

WizardStyle=modern

ArchitecturesInstallIn64BitMode=x64compatible

UninstallDisplayName={#MyAppName}
Uninstallable=yes

SetupIconFile=..\ClickerPassword\source\ico\40_104848.ico

[Files]
Source: "..\ClickerPassword\bin\Release\PasswordManager.exe"; DestDir: "{app}"; Flags: ignoreversion

[Dirs]
Name: "{app}"

[Icons]
Name: "{group}\Password Manager"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\Password Manager"; Filename: "{app}\{#MyAppExeName}"

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "Uruchom Password Manager"; Flags: nowait postinstall skipifsilent
