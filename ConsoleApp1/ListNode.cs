using System;

//esempio di classe parametrica
public class ListNode<T>
{

	public T Value { get; set; }
	public ListNode<T> NextNode { get; set; }
	
}

public class Utils
{
    //metodo generico in una classe non genrica
    public static void Swap<T>(ref T first, ref T second)
    {
        T temp = first;
        first = second;
        second = temp;
    }

    public static T Max<T>(IEnumerable<T> list) where T : IComparable //vincolo
    {
        bool isFirst = true;
        T? res = default(T);

        foreach (T item in list)
        {
            if (isFirst)
            {
                res = item;
                isFirst = false;
            }
            if (res.CompareTo(item) >= 0)
                continue;
            res = item;
        }

        return res;
    }

    public static void testNullable()
    {
        int myInt = default(int);
        Nullable<int> nullableInt = default(Nullable<int>);

        Console.WriteLine(myInt); // Stampa 0
        Console.WriteLine(nullableInt); // Stampa una riga vuota

        myInt = 5;
        nullableInt = 7; // Assegnazione di un valore intero
        var res = myInt + nullableInt; // res è di tipo Nullable<int>

        Console.WriteLine(res);

        if (nullableInt.HasValue) // Verifica presenza di un valore
        {
            var value = nullableInt.Value; // Contiene il valore int
            Console.WriteLine(value);
        }
    }
}
