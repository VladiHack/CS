public class Program
{
    public static void Main(string[] args)
    {
        int requests = int.Parse(Console.ReadLine());
        Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();
        for(int i=0;i<requests; i++)
        {
            string readClothes = Console.ReadLine();
            readClothes=readClothes.Replace(" -> ", ",");
            string[] splitClothes = readClothes.Split(",").ToArray();
            if (!clothes.ContainsKey(splitClothes[0]))
            {
                Dictionary<string,int> newDict=new Dictionary<string,int>();
                clothes.Add(splitClothes[0], newDict);
            }
            
                Dictionary<string,int> currentDictionary= clothes[splitClothes[0]];
                for (int s = 1; s < splitClothes.Length; s++)
                {
                    if (currentDictionary.ContainsKey(splitClothes[s]))
                    {
                        currentDictionary[splitClothes[s]]++;
                    }
                    else
                    {
                        currentDictionary.Add(splitClothes[s], 1);
                    }
                }
                clothes[splitClothes[0]]=currentDictionary;
            
        }
        string[] readItem = Console.ReadLine().Split().ToArray();
        string itemColor = readItem[0];string itemName= readItem[1];
        foreach (var clothesByColor in clothes)
        {
            Console.WriteLine(clothesByColor.Key+" clothes:");
            foreach (var clothing in clothesByColor.Value)
            {
                if (itemColor == clothesByColor.Key && clothing.Key == itemName)
                {
                    Console.WriteLine($"* {clothing.Key} - {clothing.Value} (found!)");
                }
                else
                {
                    Console.WriteLine($"* {clothing.Key} - {clothing.Value} ");
                }
            }
        }
    }
}