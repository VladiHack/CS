public class Program
{
    static int bracelets = 0;
    static bool usedR = false;static bool usedG = false; static bool usedB = false;
    static void Recursion(int red, int green, int blue,char startLetter,char prevLetter,int remaining)
    {
      if(remaining == 0)
        {
            bracelets++;
            Recursion(red, green, blue, ' ', ' ', 14);
        }
      if(prevLetter=='r')
        {
            usedR = true;
        }
      if(prevLetter=='b')
        {
            usedB= true;
        }
      if(prevLetter=='g')
        {
            usedG = true;
        }
      if(remaining==14)
        {
            usedR = false;usedG= false;usedB = false;
            if(red>green&&red>blue&&red>=2)
            {
                Recursion(red - 2, green, blue, 'r', 'r', 12);
            }
            else if(green>red&&green>blue)
            {
                Recursion(red, green - 2, blue, 'g', 'g', 12);
            }
            else if(blue>0)
            {
                Recursion(red, green, blue - 2, 'b', 'b', 12);
            }
        }
       else if(remaining==1)
        {
            if(usedR&&usedG&&usedB)
            {
                if (startLetter == 'r')
                {
                    if (prevLetter == 'r')
                    {
                        if (green > blue)
                        {
                            Recursion(red, green - 1, blue, startLetter, 'g', 0);
                        }
                        else if (blue > 0)
                        {
                            Recursion(red, green, blue - 1, startLetter, 'b', 0);
                        }
                    }
                    else if (prevLetter == 'g' && blue > 0)
                    {
                        Recursion(red, green, blue - 1, startLetter, 'b', 0);
                    }
                    else if (prevLetter == 'b' && green > 0)
                    {
                        Recursion(red, green - 1, blue, startLetter, 'g', 0);
                    }
                }
                else if (startLetter == 'g')
                {
                    if (prevLetter == 'g')
                    {
                        if (red > blue)
                        {
                            Recursion(red - 1, green, blue, startLetter, 'r', 0);
                        }
                        else if (blue > 0)
                        {
                            Recursion(red, green, blue - 1, startLetter, 'b', 0);
                        }
                    }
                    else if (prevLetter == 'r' && blue > 0)
                    {
                        Recursion(red, green, blue - 1, startLetter, 'b', 0);
                    }
                    else if (prevLetter == 'b' && red > 0)
                    {
                        Recursion(red - 1, green, blue, startLetter, 'r', 0);
                    }
                }
                else
                {
                    if (prevLetter == 'b')
                    {
                        if (red > green)
                        {
                            Recursion(red - 1, green, blue, startLetter, 'r', 0);
                        }
                        else if (green > 0)
                        {
                            Recursion(red, green - 1, blue, startLetter, 'g', 0);
                        }
                    }
                    else if (prevLetter == 'r' && green > 0)
                    {
                        Recursion(red, green - 1, blue, startLetter, 'g', 0);
                    }
                    else if (prevLetter == 'g' && red > 0)
                    {
                        Recursion(red - 1, green, blue, startLetter, 'r', 0);
                    }
                }
            }
            else
            {
                if(usedR==false&&red>0)
                {
                    Recursion(red - 1, green, blue, startLetter, 'r', 0);
                }
                if(usedG==false&&green>0)
                {
                    Recursion(red, green - 1, blue, startLetter, 'g', 0);
                }
                if(usedB==false&&blue>0)
                {
                    Recursion(red, green, blue - 1, startLetter, 'b', 0);
                }
            }
            
        }
        else
        {
            if(prevLetter=='r')
            {
                if(blue>green)
                {
                    Recursion(red, green, blue - 1, startLetter, 'b', remaining - 1);
                }
                else if(green>0)
                {
                    Recursion(red, green - 1, blue, startLetter, 'g', remaining - 1);
                }
            }
            else if(prevLetter=='b')
            {
                if(red>green)
                {
                    Recursion(red - 1, green, blue, startLetter, 'r', remaining - 1);
                }
                else if(green>0)
                {
                    Recursion(red, green - 1, blue, startLetter, 'g', remaining - 1);
                }
            }
            else
            {
                if(red>blue)
                {
                    Recursion(red - 1, green, blue, startLetter, 'r', remaining - 1);
                }
                else if(blue>0)
                {
                    Recursion(red, green, blue - 1, startLetter, 'b', remaining - 1);
                }
            }
        }
    }
    public static void Main(string[] args)
    {
        int red = int.Parse(Console.ReadLine());
        int green=int.Parse(Console.ReadLine());
        int blue=int.Parse(Console.ReadLine());
        Recursion(red, green, blue, ' ', ' ', 14);
        Console.WriteLine(bracelets);
    }
}