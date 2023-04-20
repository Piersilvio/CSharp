using static ConsoleApp3.Logger;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Definizione del primo delegate
            var writer = new FileLogWriter(@"c:\somefile.txt");
            var fileDelegate = new StringLogWriter(writer.Write);

            // Definizione del secondo delegate
            var consoleDelegate = new StringLogWriter(ConsoleWriter);

            // Combinazione dei delegate
            StringLogWriter combinedDelegate = (StringLogWriter)Delegate.Combine(consoleDelegate, fileDelegate);
            var myLogger = new Logger(combinedDelegate);

            // Scrive sulla console e su file il messaggio in basso
            myLogger.Log("Messaggio di esempio");
        }

        private static void ConsoleWriter(DateTime timestamp, string message)
        {
            Console.WriteLine("{0} - {1}", timestamp, message);
        }
    }

    public class FileLogWriter
    {
        public string FileName { get; set; }
        public FileLogWriter(string filename)
        {
            this.FileName = filename;
        }
        public void Write(DateTime timestamp, string message)
        {
            // Scrittura messaggio su file...
        }
    }
}