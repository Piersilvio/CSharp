using System.Drawing;

namespace ConsoleApp4
{
    internal class Program
    {
        // declaring delegate
        public delegate string MyDelegate<T>(T input) where T : struct;

        private static string DateTimeWriter(DateTime input, string n)
        {
            return input.ToShortDateString();
        }

        private static string Something(DateTime input, string n)
        {
            return "ciao";
        }

        static void Main(string[] args)
        {
            var p = new Program();
            var sample = new Func<DateTime, string, string>(DateTimeWriter);

            sample += Program.Something;
            Console.WriteLine($"{sample}");
        }
    }
}