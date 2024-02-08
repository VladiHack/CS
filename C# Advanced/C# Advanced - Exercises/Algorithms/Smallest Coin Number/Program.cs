public class Program
{
    public static void Main(string[] args)
    {
        int[] coins = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
        Dictionary<int,int> timesMetCoin=new Dictionary<int,int>();
        long desiredSum = int.Parse(Console.ReadLine());
        int totalCoins = 0;
        int lastCoin = coins.Length - 1;
        while(desiredSum > 0)
        {
            if(desiredSum >= coins[lastCoin])
            {
                if (!timesMetCoin.ContainsKey(coins[lastCoin]))
                {
                    timesMetCoin.Add(coins[lastCoin], 1);
                }
                else
                {
                    timesMetCoin[coins[lastCoin]]++;
                }
                totalCoins++;
                desiredSum-= coins[lastCoin];
            }
            else
            {
                if(lastCoin==0)
                {
                    Console.WriteLine("Error");
                    return;
                }
                lastCoin--;
            }
        }
        Console.WriteLine($"Number of coints to take: {totalCoins}");
        for(int i=coins.Length-1;i>=0; i--)
        {
            if (timesMetCoin.ContainsKey(coins[i]))
            {
                Console.WriteLine($"{timesMetCoin[coins[i]]} coins(s) with value {coins[i]}");
            }
        }
    }
}