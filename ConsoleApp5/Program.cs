namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var compositeTask = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Primo task");
            }).ContinueWith((t) =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Secondo task");
            });

            // Accodamento di una funzione
            var resultTask = compositeTask.ContinueWith((t) =>
            {
                string result = "Funzione del terzo task";
                Console.WriteLine(result);
                return result;
            });

            Console.WriteLine("Il risultato è: {0}", resultTask.Result);
        }
    }
}