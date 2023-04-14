namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var utils = new Utils();
            int a = 4, b = 5;

            int[] v = new int[] { 19, 23, 0, 4, 7 };
            List<int> l = new List<int>(v);


            Utils.Swap(ref a, ref b);
            
            Console.WriteLine($"a = {a}, b = {b}");
            Console.WriteLine($"max l = {Utils.Max(l)}\n");

            Utils.testNullable();
        }
    }
}