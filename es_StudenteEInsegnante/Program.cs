using System.Security.Cryptography;

namespace es_StudenteEInsegnante
{
    class Student
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public List<int> Scores;
    }

    class Teacher
    {
        public string First { get; set; }
        public string Last { get; set; }
        public int ID { get; set; }
        public string City { get; set; }
    }

    //userò questa classe per assegnare le properties
    //che estrapolerò dalla query
    class ClasseGiocattolo
    {
        public string First { get; set; }
        public string Last { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // creazione di una lista di studenti
            List<Student> students = new List<Student>()
            {
                new Student { First = "Svetlana",
                    Last = "Omelchenko",
                    ID = 111,
                    Street = "123 Main Street",
                    City = "Seattle",
                    Scores = new List<int> { 97, 92, 81, 60 } },
                new Student { First = "Claire",
                    Last = "O’Donnell",
                    ID = 112,
                    Street = "124 Main Street",
                    City = "Redmond",
                    Scores = new List<int> { 75, 84, 91, 39 } },
                new Student { First = "Sven",
                    Last = "Mortensen",
                    ID = 113,
                    Street = "125 Main Street",
                    City = "Seattle",
                    Scores = new List<int> { 88, 94, 65, 91 } },
            };

            // creazione di una lista di insegnanti
            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher { First = "Ann", Last = "Beebe", ID = 945, City = "Seattle" },
                new Teacher { First = "Alex", Last = "Robinson", ID = 956, City = "Redmond" },
                new Teacher { First = "Michiyo", Last = "Sato", ID = 972, City = "Tacoma" }
            };

            //assegno il risultato della query ad una ltra classe avente le stesse properties
            //var peopleInSeattle2 = from student in students
            //                       where student.City == "Seattle"
            //                       select new ClasseGiocattolo{First = student.First, Last = student.Last};

            

            var studentInSeattle = from student in students
                                   where student.City == "Seattle"
                                   orderby student.Last, student.First
                                   select new {student.First, student.Last };

            var peopleInSeattle = studentInSeattle.Concat(from teacher in teachers where teacher.City == "Seattle" select new {teacher.First, teacher.Last});

            Console.WriteLine("The following students and teachers live in Seattle:");

            //esegue la query stampando l'istanza della struttura interrogata
            foreach (var person in peopleInSeattle)
            {
                Console.WriteLine($"name {person.First}\nSurname {person.Last}");
                Console.WriteLine("\t");
            }

            //esegue la query stampando l'istanza della classe con le stesse properties estrapolate
            //foreach (var person in peopleInSeattle2)
            //{
            //    Console.WriteLine($"name {person.First}\nSurname {person.Last}");
            //    Console.WriteLine("\t");
            //}
        }
    }
}