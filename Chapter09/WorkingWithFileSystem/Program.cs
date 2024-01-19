// using Sprectre.Console;
using Spectre.Console; 

#region Handling Crossplatform file system
SectionTitle("Filesystem");
Table table = new();

table.AddColumn("[blue]MEMBER[/]");
table.AddColumn("[blue]Value[/]");

table.AddRow("Path.Directoypath",PathSeparator.ToString());
table.AddRow("Path.DirectorySeparatorChar", 
  DirectorySeparatorChar.ToString());
table.AddRow("Directory.GetCurrentDirectory()", 
  GetCurrentDirectory());
table.AddRow("Environment.CurrentDirectory", CurrentDirectory);
table.AddRow("Environment.SystemDirectory", SystemDirectory);
table.AddRow("Path.GetTempPath()", GetTempPath());
table.AddRow("");
table.AddRow("GetFolderPath(SpecialFolder", "");
table.AddRow("  .System)", GetFolderPath(SpecialFolder.System));
table.AddRow("  .ApplicationData)", 
  GetFolderPath(SpecialFolder.ApplicationData));
table.AddRow("  .MyDocuments)", 
  GetFolderPath(SpecialFolder.MyDocuments));
table.AddRow("  .Personal)", 
  GetFolderPath(SpecialFolder.Personal));
// Render the table to the console
AnsiConsole.Write(table);
#endregion


SectionTitle("Managing drives");
Table drives = new();
drives.AddColumn("[blue]NAME[/]");
drives.AddColumn("[blue]TYPE[/]");
drives.AddColumn("[blue]FORMAT[/]");
drives.AddColumn(new TableColumn(
  "[blue]SIZE (BYTES)[/]").RightAligned());
drives.AddColumn(new TableColumn(
  "[blue]FREE SPACE[/]").RightAligned());
foreach (DriveInfo drive in DriveInfo.GetDrives())
{
  if (drive.IsReady)
  {
    drives.AddRow(drive.Name, drive.DriveType.ToString(), 
      drive.DriveFormat, drive.TotalSize.ToString("N0"), 
      drive.AvailableFreeSpace.ToString("N0"));
  }
  else
  {
    drives.AddRow(drive.Name, drive.DriveType.ToString(),
      string.Empty, string.Empty, string.Empty);
  }
}
AnsiConsole.Write(drives);


#region Managing Directories
SectionTitle("Managing Directories");

string newFolder = Combine(GetFolderPath(SpecialFolder.Personal),"newfolder");
WriteLine($"Does Exits: {Path.Exists(newFolder)}");
WriteLine("Creating ...");
CreateDirectory(newFolder);

// Let's use the Directory.Exists method this time.
WriteLine($"Does it exist? {Directory.Exists(newFolder)}");
Write("Confirm the directory exists, and then press any key.");
ReadKey(intercept: true);
WriteLine("Deleting it...");
Delete(newFolder, recursive: true);
WriteLine($"Does it exist? {Path.Exists(newFolder)}");
#endregion 

#region Managing Files
SectionTitle("Managing Files");

string dir = Combine(GetFolderPath(SpecialFolder.Personal),"OutputFiles");
CreateDirectory(dir);
string textFile= Combine(dir,"Dummy.txt");
string backupFile = Combine(dir,"Dummy.bak");
WriteLine($"Working with: {textFile}");
WriteLine($"Does it exist? {File.Exists(textFile)}");

StreamWriter textWriter = File.CreateText(textFile);
textWriter.WriteLine("Heloo, C#");
textWriter.Close();

WriteLine($"Does it exist? {File.Exists(textFile)}");

File.Copy(sourceFileName: textFile,destFileName:backupFile,overwrite:true);
ReadKey(true);
WriteLine(
  $"Does {backupFile} exist? {File.Exists(backupFile)}");
Write("Confirm the files exist, and then press any key.");
ReadKey(intercept: true);
// Delete the file.
File.Delete(textFile);
WriteLine($"Does it exist? {File.Exists(textFile)}");
// Read from the text file backup.
WriteLine($"Reading contents of {backupFile}:");
StreamReader textReader = File.OpenText(backupFile); 
WriteLine(textReader.ReadToEnd());
textReader.Close();
#endregion


SectionTitle("Getting file information");
FileInfo info = new(backupFile);
WriteLine($"{backupFile}:");
WriteLine($"  Contains {info.Length} bytes.");
WriteLine($"  Last accessed: {info.LastAccessTime}");
WriteLine($"  Has readonly set to {info.IsReadOnly}.");
