using System.Collections;

public class Program
{
    public static void Main(string[] args)
    {
        int lines = int.Parse(Console.ReadLine());
        HashSet<string> usernames = new HashSet<string>();
        for(int i=0; i < lines; i++)
        {
            string name= Console.ReadLine();
            usernames.Add(name);
        }
        foreach (var username in usernames)
        {
            Console.WriteLine(username);
        }
    }
}