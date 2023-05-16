using System.Security.Cryptography.X509Certificates;

/*
 * Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una banca concede ai propri clienti.
 * La banca è caratterizzata da un nome e da un insieme di clienti. 
 * I clienti sono caratterizzati da nome, cognome, codice fiscale stipendio. 
 * Il prestito concesso al cliente, considerato intestatario del prestito, è caratterizzato da un ammontare, una rata, 
 * una data inizio, una data fine. Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti 
 * i dati che li caratterizzano in un formato di tipo stringa a piacere.
 * 
 * Per la banca deve essere possibile aggiungere, modificare, eliminare e ricercare un cliente. 
 * Inoltre, la banca deve poter aggiungere un prestito. La banca deve poter eseguire delle ricerche sui prestiti concessi 
 * ad un cliente dato il codice fiscale. 
 * La banca vuole anche sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.
 */

namespace es_Banca.it.Alten.com
{
    internal class Banca
    {
        public Banca(string Nome)
        {
            this.Nome = Nome;
            this.Clienti = new List<Cliente>();
            this.Prestiti = new List<Prestito>();
        }

        public string Nome { get; set; }
        public List<Cliente> Clienti { get; set; }
        public List<Prestito> Prestiti { get; set; }

        public void AddPrestito(Prestito Prestito)
        {
            this.Prestiti.Add(Prestito);
        }

        //uso LINQ
        public double TotalePrestiti(string CodiceFiscale)
        {
            return this.Prestiti.FindAll(p => p._Intestatario._cf == CodiceFiscale).Sum(p => p._Ammontare);
        }
        
        //uso LINQ
        public IEnumerable<Prestito> SearchPrestiti(string CodiceFiscale)
        {
            /*
             * per ogni p in List<Prestiti> dove
             * CodiceFiscale == p._Intestario._cf 
             * estrapola p
             */
            return from p in this.Prestiti where CodiceFiscale == p._Intestatario._cf select p; 
        }

        public void AddCliente(Cliente Cliente)
        {
            this.Clienti.Add(Cliente);
        }
        public void RemoveCliente(string CodiceFiscale)
        {
            this.Clienti.RemoveAll(x => x._cf == CodiceFiscale);
        }

        //uso LINQ
        public IEnumerable<Cliente> SearchCliente(string CodiceFiscale)
        {
            /*
             * per ogni p in List<Clienti>
             * dove CodiceFiscale == p._cf estrapola p
             */
            return from p in this.Clienti where CodiceFiscale == p._cf select p;
        }

        //uso LINQ
        public IEnumerable<Prestito> GetPrestitiCliente(string CodiceFiscale)
        {
            return from p in this.Prestiti where CodiceFiscale == p._Intestatario._cf select p;
        }
    }

    internal class Cliente
    {
        //properties
        public string? _nome { get; set; }
        public string? _cognome { get; set; }
        public string? _cf { get; set; }
        public double? _stip { get; set; }

        public Cliente() { }

        public Cliente(string Nome, string Cognome, string CodiceFiscale, double Stipendio)
        {
            this._nome = Nome;
            this._cognome = Cognome;
            this._cf = CodiceFiscale;
            this._stip = Stipendio;
        }

        //methods
        public override string ToString()
        {
            return string.Format($"Nome {this._nome}\tCognome {this._cognome}\tCf {this._cf}\tStipendio {this._stip}");
        }
    }

    internal class Prestito
    {
        public double _Ammontare { get; set; }
        public double _Rata { get; set; }
        public DateTime _DataInizio { get; set; }
        public DateTime _DataFine { get; set; }
        public Cliente _Intestatario { get; set; }

        public Prestito(double Ammontare, double Rata, DateTime DataInizio, DateTime DataFine, Cliente Intestatario)
        {
            this._Ammontare = Ammontare;
            this._Rata = Rata;
            this._DataInizio = DataInizio;
            this._DataFine = DataFine;
            this._Intestatario = Intestatario;
        }

        public override string ToString()
        {
            return string.Format("Ammontare: {0}\nRata: {1}\nDataInizio: {2}\nDataFine: {3}\nIntestatario:\n{4}",
                                   this._Ammontare,
                                   this._Rata,
                                   this._DataInizio,
                                   this._DataFine,
                                   this._Intestatario.ToString());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Cliente x = new Cliente("Mario", "Rossi", "MRORSI78B14FN470F", 54000);
            Cliente y = new Cliente("Luca", "Bianchi", "LCABAC78B14FN470F", 54000);

            Banca b = new Banca("EuroBanca spa");

            b.AddCliente(x);
            b.AddCliente(x);

            Prestito p1 = new Prestito(5000, 500, new DateTime(2019, 1, 10), new DateTime(2020, 1, 10), x);
            Prestito p2 = new Prestito(15000, 500, new DateTime(2019, 1, 10), new DateTime(2023, 1, 10), x);

            b.AddPrestito(p1);
            b.AddPrestito(p2);

            foreach(var i in b.SearchPrestiti("MRORSI78B14FN470F"))
            {
                Console.WriteLine(i.ToString());
                Console.WriteLine("-------------------------------");
            }

            Console.WriteLine(b.TotalePrestiti("MRORSI78B14FN470F"));
        }

    }
}