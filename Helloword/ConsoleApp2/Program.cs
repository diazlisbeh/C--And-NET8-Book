namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine(Environment.CurrentDirectory);
            Console.WriteLine(Environment.OSVersion.ToString());    
            Console.WriteLine("Namespace: {0}", typeof(Program).Namespace);
        }
    }
}