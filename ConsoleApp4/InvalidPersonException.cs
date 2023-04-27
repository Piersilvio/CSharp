using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Person(int id, string name) { 
            this.Id = id;
            this.Name = name;
        }

        public int incrementoId() { 
            
            if (this.Id < 0)
            {
                throw new InvalidPersonException("è sbagliato"); //lancio l'eccezione personalizzata
            }
            
            return this.Id; 
        }
    }

    [Serializable]
    public class InvalidPersonException: Exception
    {
        /*
         * eredito il costruttore
         * di exception
         */
        public InvalidPersonException(string message):base(message) {}  

       public void PrintMessage(InvalidPersonException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
