using ConsoleApp1.alten.it.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.alten.it.entity
{
    internal class HelloWorld : Interface1
    {
        //implemento il metodo dell'interfaccia
        void Interface1.Greeting(string name) => Console.WriteLine($"Hello, {name}!"); //sotto forma di regex
    }
}
