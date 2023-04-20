using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int y = int.Parse(Console.ReadLine());
                int x = int.Parse(Console.ReadLine());

                Console.WriteLine();

                //espressione lambda a mò di funzione
                Func<int, int, int> sum = (x, y) => x + y;

                //espressione lambda a mò di procedura (richiama l'espressione precedente!!!)
                Action<int, int> procedura = (x, y) =>
                {
                    Console.WriteLine($"richiamo sum(x, y) attraverso una procedura Action<>: {sum(x, y)}");
                };

                procedura(x, y);  

                Console.WriteLine($"richiamo sum(x, y) con Func<>: {sum(y, x)}\n");

                //uso di una lambda expression utilizzando tuple
                Func<(int, int, int), (int, int, int)> doubleThem = ns => (2 * ns.Item1, 2 * ns.Item2, 2 * ns.Item3); 
                
                var numbers = (2, 3, 4);
                var doubledNumbers = doubleThem(numbers);

                Console.WriteLine($"The set {numbers} doubled: {doubledNumbers}"); 
            }
            catch ( Exception ex ) { Console.WriteLine(ex.ToString()); }
        }
    }
}