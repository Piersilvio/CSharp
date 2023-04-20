using static ConsoleApp2.Geeks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Geeks obj = new Geeks();

            // creating object of delegate, name as "del_obj1"
            // for method "sum" and "del_obj2" for method "subtract" &
            // pass the parameter as the two methods by class object "obj"
            // instantiating the delegates
            addnum del_obj1 = new addnum(obj.sum);
            subnum del_obj2 = new subnum(obj.subtract);

            // pass the values to the methods by delegate object
            del_obj1(100, 40);
            del_obj2(100, 60);

            // These can be written as using
            // "Invoke" method
            // del_obj1.Invoke(100, 40);
            // del_obj2.Invoke(100, 60);
        }
    }
}