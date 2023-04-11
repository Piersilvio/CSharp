using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Programm<T>
    {
        private List<T> l = new();

        public List<T> getL() { return this.l; }
        public void setL(List<T> l) { this.l = l; }

        public static int sum(int x, int y) { return x + y; }

        //overloading
        public static double sum(double x, double y) { return x + y; }

        public static int lunghezzaL(List<T> l)
        {
            int x = 0;

            if (l.Count > 0)
            {
                x = l.Count;
            }
            else
            {
                x = 0;
            }

            return x; //restituisce la lunghezza di un generics
        }
    }
}
