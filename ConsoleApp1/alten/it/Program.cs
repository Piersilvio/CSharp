using ConsoleApp1.alten.it.entity;
using ConsoleApp1.alten.it.interfaces;

namespace ConsoleApp1.alten.it
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * istanzio un oggetto di tipo Interface1 che viene implementata
             * dalla classe HelloWorld
             */
            Interface1 obj = new HelloWorld();

            obj.Greeting("Pier");
        }
    }
}