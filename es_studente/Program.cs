

namespace es_studente
{
    internal class Program
    {

        static void QueryGroupByLastName()
        {
            var q = from s in Student.students
                    group s by s.LastName into newGroup
                    orderby newGroup.Key
                    select newGroup;

            foreach(var k in q)
            {
                Console.WriteLine(k.Key);
                foreach(var i in k)
                {
                    Console.WriteLine($"\t{i.LastName}, {i.FirstName}");
                }
            }
        }

        static void QueryGroupByLastNameSubstring()
        {
            var q = from s in Student.students
                    group new { s.ID } by s.LastName[2..] into newG select newG;

            foreach (var k in q)
            {
                Console.WriteLine(k.Key);
                foreach (var i in k)
                {
                    Console.WriteLine($"\t{i.ID}");
                }
            }
        }

        static void QueryGroupByPercentile()
        {
            var q = from s in Student.students
                    let p = Student.GetPercent(s)
                    group new { s.FirstName, s.LastName } by p into newG
                    select newG;

            foreach(var studentGroup in q)
{
                Console.WriteLine($"Key: {studentGroup.Key * 10}");
                foreach (var item in studentGroup)
                {
                    Console.WriteLine($"\t{item.LastName}, {item.FirstName}");
                }
            }
        }

        public static void QueryOrderByHighAVG()
        {
            var groupByHighAverageQuery = from student in Student.students
                                          group new
                                          {
                                              student.FirstName,
                                              student.LastName
                                          } by student.ExamScores.Average() > 75 into studentGroup
                                          select studentGroup;

            foreach (var studentGroup in groupByHighAverageQuery)
            {
                Console.WriteLine($"Key: {studentGroup.Key}");
                foreach (var student in studentGroup)
                {
                    Console.WriteLine($"\t{student.FirstName} {student.LastName}");
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\nuso di orderby");
            QueryHighScores(1, 90);

            Console.WriteLine("\ngroupby con una sola prop");
            QueryGroupByLastName();

            Console.WriteLine("\ngroupby dalla seconda lettera del cognome");
            QueryGroupByLastNameSubstring();

            Console.WriteLine("\ngroupby in base ad un range numerico");
            QueryGroupByPercentile();

            Console.WriteLine("\ngroupby in base ad un predicato booleano");
            QueryOrderByHighAVG();

            Console.WriteLine("\ngroupby con una chiave composta");
            QueryGroupByCompositeKey();
        }

        static void QueryGroupByCompositeKey()
        {
            var groupByCompoundKey = from student in Student.students
                                     group student by new //qui parte la def. della chiave composta da la prima lettera e la condizione
                                     {
                                         FirstLetter = student.LastName[0],
                                         IsScoreOver85 = student.ExamScores[0] > 85
                                     } into studentGroup
                                     orderby studentGroup.Key.FirstLetter
                                     select studentGroup;

            foreach (var scoreGroup in groupByCompoundKey)
            {
                 string s = scoreGroup.Key.IsScoreOver85 == true ? "more than 85" : "less than 85";
                 Console.WriteLine($"Name starts with {scoreGroup.Key.FirstLetter} who scored {s}");
                 foreach (var item in scoreGroup)
                 {
                    Console.WriteLine($"\t{item.FirstName} {item.LastName}");
                 }
            }
        }

        static void QueryHighScores(int exam, int score)
        {
            var highScores =
                from student in Student.students
                where student.ExamScores[exam] > score
                orderby student.ExamScores[exam]
                select new
                {
                    Name = student.FirstName,
                    Score = student.ExamScores[exam]
                };

            foreach (var item in highScores)
            {
                Console.WriteLine($"{item.Name,-15}{item.Score}");
            }
        }
    }
}