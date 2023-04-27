using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    /*
     * implemento i metodi presenti in IDisposable!
     */
    internal class DisposableObject : IDisposable
    {
        //reso virtual in modo da poter effettuare poi @Ovveride
        protected virtual void DisposeObject(bool disposing)
        {
            if (disposing)
            {
                //si liberano le risorse gestite
            }

            //si liberano le risorse non gestite
        }
        
        //overloading della firma del metodo dell'IDisposable
        public void Dispose()
        {
            this.DisposeObject(true);
            GC.SuppressFinalize(this);
        }

        //distruttore che forza la liberazione delle risorse non gestite
        ~DisposableObject() { this.DisposeObject(false); }

        public string someMethod(string str) { return str; }
    }
}
