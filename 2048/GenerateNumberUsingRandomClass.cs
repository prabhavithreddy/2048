using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Factset
{
    public class GenerateNumberUsingRandomClass : IRandomNumber
    {
        public int GetRandomNumber(int max)
        {
            if (max == 0)
                throw new ArgumentException("Game has ended");
            return new Random().Next(0, max);
        }
    }
}
