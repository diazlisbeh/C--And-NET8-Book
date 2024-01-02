    partial class Program
    {
        
        static void MyFunction()
        {
            WriteLine($"{typeof(Program).Namespace ?? "Es null"}");
            WriteLine("Execuiting my function");
        }
    }
