using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaXOR
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n - 1];
            for (int i = 0; i < array.Length; i++)
                array[i] = Convert.ToInt32(Console.ReadLine());
            int count = 0;
            Dictionary<int, List<int>> set1 = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> set2 = new Dictionary<int, List<int>>();
            
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    List<int> a = new List<int>();
                    List<int> b = new List<int>();
                    set1.Add(count, a);
                    a.Add(array[j]);
                }
                for (int k = 0; k < n; k++)
                {
                    if (!a.Contains(array[k]))
                    {
                        b.Add(array[k]);
                    }
                }
                set2.Add(count, b);
                count++;
            }
            System.Console.WriteLine("Hello World!\n");
        }
    }
}
