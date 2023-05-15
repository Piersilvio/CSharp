using System.Runtime.CompilerServices;

namespace ConsoleApp4
{
    internal class Program
    {
       public static int incremento(int a) {

            return a += 1; 
        }

        static void Main(string[] args)
        {
            //creazione di un task semplice
            var simpleTask = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("ciao da SimpleTask");
            });

            //costruzione di un task con parametro in input
            var parameterTask = Task.Factory.StartNew((nome) =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("ciao da {0}", nome);
            }, "pieroSilvio");

            var resTask = Task.Factory.StartNew((valInput) => incremento(4), 4);

            //metto in attesa il thread chiamante per far eseguire il thread
            resTask.Start();
            resTask.Wait();
            simpleTask.Wait();
            parameterTask.Wait();
        }   
    }
}