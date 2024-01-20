public class Program
{
    static int size;
    static List<string> priority;
    static void Recursion(string[] arr,int index,int used,string collection)
    {
        if(index==arr.Length)
        {
            return;
        }
        if(size==used)
        {
            List<string> newOrder=new List<string>();
            List<string> getNums=new List<string>();
            string number = "";
            for(int i=0;i<collection.Length;i++)
            {
                if (collection[i]==' ')
                {
                    if(number!="")
                    {
                        getNums.Add(number);
                    }
                    number = "";
                }
                else
                {
                    number += collection[i];
                }
            }
            for(int i=0;i<priority.Count;i++)
            {
                if (getNums.Contains(priority[i]))
                {
                    newOrder.Add(priority[i]);
                }
            }
            for(int i=0;i<getNums.Count;i++)
            {
                if (!newOrder.Contains(getNums[i]))
                {
                    newOrder.Add(getNums[i]);
                }
            }
            Console.WriteLine(string.Join(" ",newOrder));

            return;
        }
        for(int i=index+1;i<arr.Length;i++)
        {
            Recursion(arr, i, used + 1, collection + arr[i]+" ");
        }
    }
    public static void Main(string[] args)
    {
       
            string read = Console.ReadLine();
            string[] arr = read.Split().ToArray();
            size = int.Parse(Console.ReadLine());
            priority = Console.ReadLine().Split().ToList();
            Recursion(arr, -1, 0, "");
        
    }
}