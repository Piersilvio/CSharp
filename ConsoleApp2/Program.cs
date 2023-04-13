namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pila = new Stack<int>();
            var coda = new Queue<int>();

            pila.Push(1);
            pila.Push(2);
            pila.Push(3);

            coda.Enqueue(pila.Count);   //inserisco il #(el) della pila
            coda.Enqueue(pila.Pop());   //inserisco in coda l'ultimo elemento poppato
            coda.Enqueue(coda.Count);   //inserisco in coda il #(el) della pila

            Console.WriteLine("Pila:");
            foreach (int i in pila)
            {
                Console.WriteLine($"\t{i}");
            }

            Console.WriteLine("\nCoda:");
            foreach (int i in coda)
            {
                Console.WriteLine($"\t{i}");
            }
        }
    }
}