public class Program
{
    static string read;
    static List<string> met=new List<string>();
    static string res = "";
    static int maxSize = 0;
    static void Recursion(int index,string collection)
    {
        if (!string.IsNullOrEmpty(collection))
        {
            if (met.Contains(collection))
            {
                if (maxSize < collection.Length)
                {
                    maxSize = collection.Length;
                    res = collection;
                }
                else if (maxSize == collection.Length && String.Compare(res, collection) < 0)
                {
                    res = collection;
                }
            }
            else
            {
                met.Add(collection);
            }
        }
        
        for (int i=index+1;i<read.Length;i++)
        {
            Recursion(i, collection + read[i]);
        }
    }
    public static void Main(string[] args)
    {
        int t = int.Parse(Console.ReadLine());
        for(int i=0;i<t; i++)
        {
            met.Clear();
             read= Console.ReadLine();
            maxSize = 0;
            Recursion(-1, "");
            Console.WriteLine(res);

        }

    }
}