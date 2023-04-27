namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p = new Person(-1, "piero"); //il -1 genererà l'eccezione

            try
            {
                p.incrementoId();
            }catch (InvalidPersonException e) //catturo un eccezione personalizzata
            {
                e.PrintMessage(e);
            }
        }
    }
}