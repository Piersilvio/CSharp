namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int res = 0;

            try
            {
                res = Division(5, 0);
                Console.WriteLine(res);

            }catch(DivideByZeroException ex)
            {
                /*
                 * nel caso in cui il CLR trova in stack
                 * il blocco catch che può risolvere l'eccezione
                 * (ossia quel catch che ha lo stesso tipo di exception)
                 * allora lo risolve!
                 */
                Console.WriteLine("Attempted divide by zero."); //stamperà il messaggio
            }
        }

        public static int Division(int x, int y) {  
            
            if(y == 0)
            {
                /*
                 * se y = 0 => faccio sollevare l'eccezione e
                 *             lo faccio gestire all'interno del 
                 *             main() (che non è altro che il metodo chiamante!!)          
                 */
                throw new DivideByZeroException(); 
            }
            
            return x / y; 
        }
    }
}