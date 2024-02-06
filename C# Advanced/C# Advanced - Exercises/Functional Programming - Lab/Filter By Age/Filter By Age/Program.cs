public class Program
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Dictionary<string,int> nameAge=new Dictionary<string,int>();
        for(int i=0;i<n; i++)
        {
            string[] read = Console.ReadLine().Split(", ").ToArray();
            nameAge.Add(read[0], int.Parse(read[1]));

        }
        string olderOrYounger=Console.ReadLine();
        int age = int.Parse(Console.ReadLine());
        string[] parameters = Console.ReadLine().Split().ToArray();
            foreach (var item in nameAge)
            {
                if ((olderOrYounger == "older" && age <= item.Value) || (olderOrYounger == "younger" && age >= item.Value))
                {
                    if (parameters.Length == 2)
                    {
                        Console.WriteLine(item.Key + " - " + item.Value);
                    }
                    else if (parameters[0] == "name")
                    {

                        Console.WriteLine(item.Key);
                    }
                    else
                    {
                        Console.WriteLine(item.Value);
                    }
                }
               
            }
        
    }
}