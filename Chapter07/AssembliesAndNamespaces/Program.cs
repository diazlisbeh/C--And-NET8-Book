using System;
using System.Xml.Linq;
#region Importing a namespace to use a type
XDocument doc = new();
#endregion

#region Relating keywords and .NET Types
string s1 = "Hello";
String s2 = "World";
WriteLine($"{s1} {s2}");

#endregion

#region 
WriteLine($"Environment.Is64BitProcess = {Environment.Is64BitProcess}");
WriteLine($"int.MaxValue = {int.MaxValue:N0}");
WriteLine($"nint.MaxValue = {nint.MaxValue:N0}");

#endregion