public class Program
{
   public static void Main(string[] args)
    {
        List<string> list = new List<string>();
        while(true)
        {
            string[] read = Console.ReadLine().Split(", ").ToArray();
            if (read[0] == "END")
            {
                if(list.Count == 0)
                {
                    Console.WriteLine("Parking Lot is Empty");
                }
                else
                {
                    for(int i=0; i<list.Count; i++)
                    {
                        Console.WriteLine(list[i]);
                    }
                }
                return;
            }
            if (read[0] =="IN" && list.Contains(read[1])==false)
            {
                list.Add(read[1]);
            }
            else if (list.Contains(read[1]) && read[0]=="OUT")
            {
                list.Remove(read[1]);
            }
        }
    }
}