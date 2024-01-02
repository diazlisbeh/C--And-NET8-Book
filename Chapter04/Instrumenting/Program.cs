using System.Diagnostics;
using Microsoft.Extensions.Configuration;


string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt");
Console.WriteLine($"Writing to: {logPath}");
TextWriterTraceListener logFile = new(File.CreateText(logPath));
Trace.Listeners.Add(logFile);
#if DEBUG

Trace.AutoFlush = true;
#endif


Debug.WriteLine("Debugs says, I am watching!");
Trace.WriteLine("Trace says, I am watching!");


string settingsFile = "appsettings.json";
string settingsPath = Path.Combine(Directory.GetCurrentDirectory(), settingsFile);
Console.WriteLine("Processing: {0}", settingsPath);
Console.WriteLine("--{0} contents--", settingsFile);
Console.WriteLine(File.ReadAllText(settingsPath));
Console.WriteLine("----");

ConfigurationBuilder builder = new();
builder.SetBasePath(Directory.GetCurrentDirectory());


builder.AddJsonFile(settingsFile,false,true);

IConfigurationRoot configuration = builder.Build();
TraceSwitch ts = new(displayName: "PacktSwitch", description: "This swicth is set via a JSON config.");
configuration.GetSection("PacktSwitch").Bind(ts);
Console.WriteLine($"Trace switch value: {ts.Value}");
Console.WriteLine($"Trace switch level: {ts.Level}");

Trace.WriteLine(ts.TraceError,"Trace error");
Trace.WriteLine(ts.TraceWarning,"Trace warning");
Trace.WriteLine(ts.TraceInfo,"Trace info");
Trace.WriteLine(ts.TraceVerbose,"Trace Verbose");



Debug.Close();
Trace.Close();

Console.WriteLine("Press enter to exit.");
Console.ReadLine();
