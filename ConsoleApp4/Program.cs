using System;
using System.Linq;

namespace patternstrength
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int[] iArray = new int[20];
                Console.WriteLine("please enter a series of letters and numbers");
                string line = Console.ReadLine();
                int i = 0;
                string numbers = new string(line.Where(c => char.IsDigit(c)).ToArray());
                Console.WriteLine(numbers);
                foreach (char c in numbers)
                {
                    Console.WriteLine(c);
                    iArray[i] = (int)char.GetNumericValue(c);
                    i++;
                }
                int altres = 0;
                int sumres = 0;
                int sumpos = 0;
                int sumneg = 0;
                int j = 1;
                foreach (int a in iArray)
                {
                    if (j % 2 == 1)
                    {
                        altres += a;
                    }
                    else
                    {
                        altres -= a;
                    }
                    if (a % 2 == 1)
                    {
                        sumneg += a;
                    }
                    else
                    {
                        sumpos += a;
                    }
                    sumres += a;
                    j++;
                }
                int N = i;
                int posneg = Math.Abs(sumpos - sumneg);
                var sda = 0;
                if (N > 0)
                {
                    try
                    {
                        sda = (sumres / altres);
                    }
                    catch (DivideByZeroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("substituted 0 for 1");
                        sda = (sumres / 1);
                    }
                    altres = Math.Abs(altres);
                    sda = Math.Abs(sda);
                    int avg = (sumres / N);
                    int score = 0;
                    if (altres == 0 || avg == 0)
                    {
                        score = 2;
                    }
                    if (posneg == altres)
                    {
                        score++;
                        score++;
                    }
                    if (posneg == avg)
                    {
                        score++;
                    }
                    if (altres == avg)
                    {
                        score++;
                        score++;
                    }
                    if ((sda * avg) == sumres)
                    {
                        score++;
                    }
                    if ((sumpos == 0) || (sumneg == 0))
                    {
                        if (avg == sda)
                        {
                            score++;
                        }
                    }
                    if ((altres + posneg) == (sumpos))
                    {
                        score++;
                    }
                    if ((altres + posneg) == (sumneg))
                    {
                        score++;
                    }
                    if ((avg + sda) == Math.Ceiling((double)sumres / 2) || (avg + sda) == N)
                    {
                        score++;
                        score++;
                    }
                    if ((((sumres / posneg) + 1) == sumneg) || (((sumres / posneg) + 1) == sumpos))
                    {
                        if ((((sumres / posneg) - 1) == sumneg) || (((sumres / posneg) - 1) == sumpos))
                        {
                            score++;
                        }
                    }


                    if ((N <= 2) && (score >= 3))
                    {
                        score = 2;
                    }

                    Console.WriteLine(
                        "\n" +
                        "sum = {0}\n" +
                        "Alt sum = {1}  (Absolute)\n" +
                        "N = {2}\n" +
                        "avg = {3}\n" +
                        "sum of pos = {4}\n" +
                        "sum of neg = {5}\n" +
                        "pos - neg = {6}  (Absolute)\n" +
                        "sum/altsum = {7}  (Absolute)\n" +
                        "\n" +
                        "Pattern Score {8}"

                        , sumres, altres, N, avg, sumpos, sumneg, posneg, sda, score);
                }
            }
        }
    }
}
