public class Program
{
    public static void Main(string[] args)
    {
        int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
        while(true)
        {
            string read = Console.ReadLine();
            if (read == "end")
            {
                break;
            }
            else
            {
                if(read=="add")
                {
                    for (int i = 0; i < nums.Length; i++)
                        nums[i]++;
                }
                else if(read=="multiply")
                {
                    for (int i = 0; i < nums.Length; i++)
                        nums[i] *= 2;
                }
                else if(read=="subtract")
                {
                    for (int i = 0; i < nums.Length; i++)
                        nums[i]--;
                }
                else if(read=="print")
                {
                    Console.WriteLine(String.Join(" ",nums));
                }
            }
        }
    }
}