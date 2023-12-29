using System.Collections;
using System.Collections.Specialized;

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
        // Int can be successfully add into array list, but error will happen, see Noet1 above.
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