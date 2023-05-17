using System.Collections.Immutable;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * un array è possibile enumerarlo
             * quini IEnumerable<T> funziona e 
             * funziona anche LINQ!
             */

            int[] vector = { 1, 2, 3, 0, 54, 4, 102, 65};

            /*
             * "per ogni x in vector
             * dove x > 50 ordina x in decrescente e estrapola x"
             * 
             * a differenza di SQL, l'ordine di LINQ è inverso!!!!
             */
            IEnumerable<int> query =
                from x in vector where x > 50 orderby x descending select x;

            //mostro il risultato della query
            foreach (int x in query)
            {
                Console.WriteLine(x);
            }

            //----------- con l'uso di un generics (enumerabile) ------------------

            //istanzio una lista di interi
            List<int> list = new List<int>(vector);

            var q = from x in list where x > 50 orderby x descending select x;

            foreach (int x in q)
            {
                Console.WriteLine(x);
            }

            //------------------- con l'uso di lambda exp ------------------------

            var q1 = list.Where(x => x > 50).ToList();
            q1.Sort();
            foreach(int x in q1)
            {
                Console.WriteLine(x);
            }
        }
    }
}