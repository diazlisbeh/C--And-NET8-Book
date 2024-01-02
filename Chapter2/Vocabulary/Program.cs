// See https://aka.ms/new-console-template for more information
using System.Reflection;
Console.WriteLine("Hello, World!");

#region Three variables 
int decimaNotation = 2_000_000;
int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
int hexadecimalNotation = 0x_001E_8480;
#endregion

System.Data.DataSet ds = new System.Data.DataSet();
HttpClient client = new HttpClient();

WriteLine($"Computer named {Env.MachineName} says \"No.\"\n\n");

Assembly? asm = Assembly.GetEntryAssembly();

if (asm is null) return;

foreach (AssemblyName name in asm.GetReferencedAssemblies())
{
    Assembly a = Assembly.Load(name);

    int methodCount = 0;

    foreach(TypeInfo t in a.DefinedTypes)
    {
        methodCount += t.GetMethods().Length;
    }

    WriteLine("{0} types with {1} methods in {2} assembly",
        arg0: a.DefinedTypes.Count(),
        arg1: methodCount,
        arg2: name.Name);
}
