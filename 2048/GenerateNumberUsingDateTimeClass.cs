using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Factset
{
    public class GenerateNumberUsingDateTimeClass : IRandomNumber
    {
        private DateTime dateTime;
        public GenerateNumberUsingDateTimeClass()
        {
            dateTime = DateTime.Now;
        }
        public GenerateNumberUsingDateTimeClass(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }
        public int GetRandomNumber(int max)
        {
            if (max > 0 && max < 1000)
                return new Random().Next(0, dateTime.Millisecond % max);
            else
                throw new ArgumentException("max should be between 1 and 999");
        }
    }
}
