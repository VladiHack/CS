public class Program
{
    public static void Main(string[] args)
    {
        Dictionary<string,Dictionary<string, double>> shop = new Dictionary<string, Dictionary<string, double>>();
         while(true)
        { 
            string[] split = Console.ReadLine().Split(", ").ToArray();
            if (split[0] == "Revision")
            {
                shop = shop.OrderBy(x => x.Key).ToDictionary(pair=>pair.Key, pair => pair.Value);
                foreach (var item in shop)
                {
                    Console.WriteLine(item.Key + "->");
                    foreach (var item2 in item.Value)
                    {
                        Console.WriteLine($"Product: {item2.Key}, Price: {item2.Value}");
                    }
                }
                return;
            }
            if (!shop.ContainsKey(split[0]))
            {
                    Dictionary<string, double> products = new Dictionary<string, double>();
                    shop.Add(split[0], products);
            }           
            Dictionary<string, double> prevProducts = shop[split[0]];
            prevProducts.Add(split[1], double.Parse(split[2]));
            shop[split[0]] = prevProducts;
           
        }
    }
 }
    