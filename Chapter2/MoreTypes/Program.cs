using System.Xml;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var xml1 = new XmlDocument();
XmlDocument xml2 = new XmlDocument();

var file1 = File.CreateText("somethist1.txt");

StreamWriter file2 = File.CreateText("somjtk.txt");

Console.WriteLine($"default(int) = {default(int)}");
Console.WriteLine($"default(bool) = {default(bool)}");
Console.WriteLine($"default(DateTime) = {default(DateTime)}");
Console.WriteLine($"default(string) = {default(string)}");

