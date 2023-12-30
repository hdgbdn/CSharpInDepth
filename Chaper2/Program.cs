using System.Collections;
using System.Collections.Specialized;
using System.Globalization;

public class Program
{
    static void Main()
    {
        // print string array
        Console.WriteLine("Now printing string array");
        foreach (string name in Functions_2_1.GenerateNames_Array())
        {
            Console.WriteLine(name);
        }

        // print arraylist
        // Note 1: 
        // If there is a non-string in this array list
        // 'Unable to cast object of type 'System.Int32' to type 'System.String'.'
        // will occur.
        // So, there is a implicit cast here.
        Console.WriteLine("Now printing string array list");
        foreach (string name in Functions_2_1.GenerateNames_ArrayList())
        {
            Console.WriteLine(name);
        }

        // print string collection
        Console.WriteLine("Now printing string collection");
        foreach (string name in Functions_2_1.GenerateNames_StringCollection())
        {
            Console.WriteLine(name);
        }

        // print generics List<string>
        Console.WriteLine("Now printing generics List<string>");
        foreach (string name in Generics_2_1_2.GenerateNames())
        {
            Console.WriteLine(name);
        }

        // Trying the collection copying
        Console.WriteLine("Now copying collection at most");
        List<int> numbers = new List<int>();
        numbers.Add(1);
        numbers.Add(10);
        numbers.Add(100);
        List<int> firstOne = Generics_2_1_2.CopyAtMost<int>(numbers, 1);
        Console.WriteLine($"the copied length is {firstOne.Count}");

        // 2.1.4
        // Or you can call CopyAtMost without specify the type argument
        // maybe the compiler can infer that.
        List<int> firstOne_2 = Generics_2_1_2.CopyAtMost(numbers, 1);
        Console.WriteLine("Now copying collection at most with out using type argument");
        Console.WriteLine($"the copied length is {firstOne_2.Count}");


        // Create tuple without specify the type
        var tuple_1 = new Tuple<int, string, int>(10, "x", 20);
        var tuple_2 = Tuple.Create(10, "x", 20);
        Console.WriteLine($"Is new Tuple<int, string, int> has same type with Tuple.Create? {tuple_1.GetType() == tuple_2.GetType()}");

        // 2.1.5
        Console.WriteLine("Using where T :");
        PrintItems(new List<decimal>{3/2, 2/6});
    }

    
        // 2.1.5 Type constraints
        // Instead of static void PrintItems(List<IFormattable> items)
        // do
        static void PrintItems<T>(List<T> items) where T : IFormattable
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            foreach (T item in items)
            {
                Console.WriteLine(item.ToString(null, culture));
            }
        }
}

public class Functions_2_1
{
    public static string[] GenerateNames_Array()
    {
        string[] names = new string[4];
        names[0] = "Gamma";
        names[1] = "Vlissides";
        names[2] = "Johnson";
        names[3] = "Helm";
        return names;
    }

    public static ArrayList GenerateNames_ArrayList()
    {
        ArrayList names = new ArrayList();
        names.Add("Gamma");
        names.Add("Vlissides");
        names.Add("Johnson");
        names.Add("Helm");

        // Note 1:
        // Int can be successfully add into array list, but runtime error will happen, see Noet1 above.
        // names.Add(123);
        return names;
    }

    public static StringCollection GenerateNames_StringCollection()
    {
        StringCollection names = new StringCollection();
        names.Add("Gamma");
        names.Add("Vlissides");
        names.Add("Johnson");
        names.Add("Helm");

        // Note 2:
        // Unlike using array list(Note 1), the StringCollection will do type check
        // so a int can not been added into the StringCollection
        // names.Add(123);
        return names;
    }
}

// Here comes the Generics!
public class Generics_2_1_2
{
    public static List<string> GenerateNames()
    {
        List<string> names = new List<string>();
        names.Add("Gamma");
        names.Add("Vlissides");
        names.Add("Johnson");
        names.Add("Helm");

        // Compiler error will occur when add something with different type.
        // names.Add(123);
        return names;
    }

    // A method with type parameter
    public static List<T> CopyAtMost<T>(List<T> input, int maxElements)
    {
        int actualCount = Math.Min(input.Count, maxElements);
        List<T> ret = new List<T>(actualCount);
        for(int i = 0; i < actualCount; i++)
        {
            ret.Add(input[i]);
        }
        return ret;
    }

    // also same name but a different generic arity
    public void Method() {}
    public void Method<T>() {}
    public void Method<T1, T2>() { }

    // even more extremly examples
    public enum IAmConfusing { }
    public class IAmConfusing<T> { }
    public struct IAmConfusing<T1, T2> { }
    public interface IAmConfusing<T1, T2, T3, T4> { }

    // but duplicate type parameter is not allowed
    // public void MethodSameType<T, T>() {}
}

// All of the following have to be non-generic
// Fields
// Properties
// Indexers
// Constructors
// Events
// Finalizers

public class AClassContainsAGenericLikeFiled_2_1_3<TItem>
{
    // The type argument TItem is introduced by class,
    // doesn't mean that this property is generic
    private readonly List<TItem> items = new List<TItem>();
}