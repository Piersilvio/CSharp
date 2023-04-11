using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Programm<double> program_double = new();
            Programm<int> program_int = new();

            Console.WriteLine($"senza overloading (somma intera): {Programm<int>.sum(3,4)}");
            Console.WriteLine($"con overloading (somma in virgola mobile): {Programm<double>.sum(3.1, 4.4)}");
            
            
            List<double> list = new List<double>();
            List<int> list_int = new List<int>();

            program_double.setL(list);
            program_int.setL(list_int);

            program_int.getL().Add(Programm<int>.sum(5, 10));
            program_int.getL().Add(Programm<int>.sum(3, 10));

            program_double.getL().Add(Programm<double>.sum(5.1, 10));
            program_double.getL().Add(Programm<double>.sum(3, 10.3)); 
            program_double.getL().Add(Programm<double>.sum(5.5, 10));
            program_double.getL().Add(Programm<double>.sum(3.7, 10));

            Console.WriteLine($"Lunghezza lista double: {Programm<double>.lunghezzaL(program_double.getL())}");
            Console.WriteLine($"Lunghezza lista int: {Programm<int>.lunghezzaL(program_int.getL())}");
        }
    }
}