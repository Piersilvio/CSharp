namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * invoco la classe per gestire
             * la deallocazione dell'oggetto
             */
            var mioOggetto = new DisposableObject();

            try
            {
                Console.WriteLine($"{mioOggetto.someMethod("Pierino")}");  
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }finally { 
                /*
                 * dopo che il try{} termina e non 
                 * si sono verificate eccezioni, allora l'oggetto
                 * viene deallocato! (non intervine il garbage!!)
                 */
                mioOggetto.Dispose();
            }
        }
    }
}