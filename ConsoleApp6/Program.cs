using System.Net;
using System.Runtime.CompilerServices;

namespace ConsoleApp6
{
    internal class Program
    {
        //il thread rimane in attesa finché non recupererà tutto il contenuto da url!
        static void Download(string url)
        {
            if(url != null)
            {
                Console.WriteLine("download {0}: ", url);

                WebRequest c = WebRequest.Create(url);
                var response =  c.GetResponse();

                using var reader = new StreamReader(response.GetResponseStream());
                //esec. sincrona della request
                var result = reader.ReadToEnd();
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("impossibile scaricare il contenuto da {0}", url);
            }
        }

        //il thread recupera il contenuto in modo asincrono e non rimane bloccato!! (restituisce 
        public static async Task<int> DownloadAsync(string url)
        {
            int prova = 0;
            if (url != null)
            {
                Console.WriteLine("download asincrono {0}: ", url);

                WebRequest c = WebRequest.Create(url);
                var response = c.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    //esec. asincrona della request (in questo caso scrivo su un file il contenuto
                    using (StreamWriter writer = new StreamWriter(@"C:\Users\pspicoli\Desktop\testoPagiAda.txt"))
                    {
                        if (writer is null)
                        {
                            Console.WriteLine("errore");
                            prova = 1;
                        }
                        else
                        {
                            writer.WriteLine(await reader.ReadToEndAsync());
                            prova = 2;
                        }
                      
                        writer.Close();
                    }
                }
            }
            else
            {
                Console.WriteLine("impossibile scaricare il contenuto da {0}", url);
            }
            return prova;
        }
        static async Task<int> RunOp()
        {
            string url = "https://elearning.di.uniba.it/";

            Download(url);
            var download = DownloadAsync(url);
            await SequentialOperations();
            Console.WriteLine(await download);
            await SequentialOperationsAsync();

            return 0;
        }

        static async Task Main(string[] args)
        {
            var c = await RunOp();
            Console.WriteLine(c);
        }

        //esecuzione seq. del task in asincrono
        public static async Task SequentialOperations()
        {
            Console.WriteLine("---- SequentialOperations ----");

            HttpClient client = new HttpClient();

            var firstResult = await client.GetStringAsync("http://www.google.com");
            Console.WriteLine(firstResult);

            var secondResult = await client.GetStringAsync("http://www.yahoo.com");
            Console.WriteLine(secondResult);

            var thirdResult = await client.GetStringAsync("http://www.bing.com");
            Console.WriteLine(thirdResult);
        }

        //esec. parallela asinc.
        public static async Task SequentialOperationsAsync()
        {
            Console.WriteLine("---- Parallel ----");

            HttpClient client = new HttpClient();

            var tasks = new List<Task<string>>()
            {
                client.GetStringAsync("http://www.google.com"),
                client.GetStringAsync("http://www.yahoo.com"),
                   client.GetStringAsync("http://www.bing.com")
            };

            await Task.WhenAll(tasks); //attendo che tutte le chiamate terminino!

            foreach (var task in tasks)
            {
                Console.WriteLine(task.Result);
            }
        }

    }
}