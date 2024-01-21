public class Program
{
    public static void Main(string[] args)
    {
        List<string> names=Console.ReadLine().Split().ToList();
        int passToN = int.Parse(Console.ReadLine());
        passToN -= 1;
        int position = 0;
        while(names.Count()>1)
        {
            position += passToN;
            if(position>=names.Count())
            {
                position%=names.Count();
            }
            Console.WriteLine("Removed "+names[position]);
            names.RemoveAt(position);
        }
        Console.WriteLine("Last is " + names[0]);
    }
}