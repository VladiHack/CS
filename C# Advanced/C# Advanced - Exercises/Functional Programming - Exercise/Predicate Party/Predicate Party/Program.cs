public class Program
{
    public static void Main(string[] args)
    {
        List<string> names = Console.ReadLine().Split().ToList();
        while(true)
        {
            string read = Console.ReadLine();
            if(read=="Party!")
            {
                if(names.Count>0)
                {
                    names.Sort();
                    Console.WriteLine(string.Join(", ", names) + " are going to the party!");
                }
                else
                {
                    Console.WriteLine("Nobody is going to the party!");
                }
                break;
            }
            string[] split = read.Split().ToArray();
            if (split[0]=="Remove")
            {
                if (split[1]== "StartsWith")
                {
                    names = names.Where(p => !p.StartsWith(split[2])).ToList();
                }
                else if (split[1]=="EndsWith")
                {
                    names = names.Where(p => !p.EndsWith(split[2])).ToList();
                }
                else
                {
                    names = names.Where(p => p.Length!=int.Parse(split[2])).ToList();
                }
            }
            else
            {
                List<string> listToAdd= new List<string>();
                if (split[1] == "StartsWith")
                {
                    listToAdd = names.Where(p => p.StartsWith(split[2])).ToList();
                }
                else if (split[1] == "EndsWith")
                {
                    listToAdd = names.Where(p => p.EndsWith(split[2])).ToList();
                }
                else
                {
                    listToAdd = names.Where(p => p.Length == int.Parse(split[2])).ToList();
                }
                foreach (var item in listToAdd)
                {
                    names.Add(item);
                }
            }
        }
    }
}