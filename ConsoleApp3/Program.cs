using System.Collections.Generic;
using System.Reflection.Metadata;

namespace ConsoleApp3
{
    internal class Program
    {
        public delegate int UnDelegate(string parameter);

        static void Main(string[] args)
        {

            //passo un ist6anza di tipo object (qualunque tipo)
            var t1 = new Thread((String) =>
            {
                Thread.Sleep(5000);
                Console.WriteLine($"saluti da {String}");
            });

            //per overloading passo un tipo
            t1.Start("salvatore");

            Console.WriteLine("Hello, World! da thread main");


            //fenomeno di race condition

            var n = "piero";

            var t1 = new Thread(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine($"saluti da {n}");
            });

            t1.Start();
            n = "giacomo"; //t1 dipenderà dall'assegnazione fatta dal primary thread (cioe il main())



            //gestione del flusso di esecuzione
            //creo una lista di 5 thread con lo stesso comportamento

            var listT = new List<Thread>();

            for (int i = 0; i < 5; i++)
            {
                var t = new Thread((currentIndex) =>
                {
                    Console.WriteLine("Thread {0} è iniziato", currentIndex);

                    Thread.Sleep(3000);
                    Console.WriteLine("Thread {0} è terminato", currentIndex);
                });

                //faccio partire i 5 thread
                t.Start(i);

                //e lio aggiungo in lista
                listT.Add(t);
            }

            // Attesa del completamento di ognuno dei worker thread (fatto dal primary thread che è il main())
            foreach (Thread thread in listT)
            {
                thread.Join();
            }

            Console.WriteLine("Esecuzione di tutti i thread terminata");



            //uso del metodo abort()
            var workerThread = new Thread(() =>
            {
                try
                {
                    Console.WriteLine("Inizio di un thread molto lungo");
                    Thread.Sleep(5000);
                    Console.WriteLine("Termine worker thread");
                }
                catch (ThreadAbortException ex)
                {
                    Console.WriteLine($"{ex.Message}");
                }

            });

            workerThread.Start();
            workerThread.Join(500);

            // Se il worker thread è ancora in esecuzione lo si cancella
            if (workerThread.ThreadState != ThreadState.Stopped)
            {
                workerThread.Abort();
            }
            Console.WriteLine("Termine applicazione");


            //uso del ThreadPool
            ThreadPool.QueueUserWorkItem((o) =>
            {

                Console.WriteLine("metodo del thread");
                Thread.Sleep(1000);
                Console.WriteLine("fine esecuzione del metodo thread");
            });

            Thread.Sleep(500); //partirà da qui il metodo del thread
            Console.WriteLine("metodo main");
            Thread.Sleep(2000);


            //uso threadPool parametrizzato
            var m = "piero";

            ThreadPool.QueueUserWorkItem((argument) =>
            {
                Thread.Sleep(500);
                Console.WriteLine("saluti da {0}", argument);
            }, m);

            m = "giacomo"; //non apparirà giacomo
            Thread.Sleep(2000);



            var l = new List<ManualResetEvent>();

            try
            {
                for (int i = 0; i < 5; i++)
                {
                    //creazione del waitHandle per il task corrente
                    var waitHandle = new ManualResetEvent(false);
                    l.Add(waitHandle);

                    //oggetto da passare al task accodato
                    var state = new Tuple<int, ManualResetEvent>(i, waitHandle);

                    ThreadPool.QueueUserWorkItem((untypedState) =>
                    {

                        // casting in object per il WaitCallback
                        var taskState = (Tuple<int, ManualResetEvent>)untypedState;

                        //visualizzazione messaggi in console
                        Console.WriteLine("thread {0} è iniziato", taskState.Item1);
                        Thread.Sleep(500);
                        Console.WriteLine("thread {0} è terminato", taskState.Item1);

                        //segnalazione del termine di esecuzione del task utilizzando il set di ManualResetEvent
                        taskState.Item2.Set();

                    }, state);
                }

                //attesa che tutti i manualResetEvent siano in stato di set
                foreach (var handle in l)
                {
                    handle.WaitOne();
                }
            }
            finally
            {
                foreach (var handle in l)
                {
                    handle.Dispose();
                }
            }

            Console.WriteLine("esecuzione terminata");



            var method = new UnDelegate((parameter) =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Ciao da {0}", parameter);
                return parameter.Length;
            });

            method.BeginInvoke("Matteo Tumiati", MyCallback, null);
            Console.WriteLine("Esecuzione avviata");
            Console.ReadLine();

        }
        public static void MyCallback(IAsyncResult ar)
        {

            Console.WriteLine("Esecuzione terminata");
            var method = (UnDelegate)ar.AsyncState;
            int ris = method.EndInvoke(ar);

            Console.WriteLine("risultato {0}", ris);
        }



    }
}
}