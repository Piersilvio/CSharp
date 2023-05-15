namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Thread t2 = new Thread(() => {
                Thread.Sleep(8000); //8 sec.
                Console.WriteLine("Partenza thread t2");
            });

            //esecuzione t2
            t2.Start();

            //esecuzione thread principale
            Console.WriteLine("partenza thread principale main");
        }
    }
}