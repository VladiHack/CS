public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<double,int> dict=new Dictionary<double,int>();
        double[] arr = Console.ReadLine().Split(" ").Select(double.Parse).ToArray();
        for(int i=0;i<arr.Length; i++)
        {
            if (dict.ContainsKey(arr[i]))
            {
                dict[arr[i]]++;
            }
            else
            {
                dict.Add(arr[i], 1);
            }
        }
        foreach(var item in dict)
        {
            Console.WriteLine(item.Key + " - " + item.Value + " times");
        }
    }
}