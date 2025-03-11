using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluebikTest.Interfaces;

namespace BluebikTest.Services
{
    public class NumberConvertsionService : INumberConvertsionService
    {
        public int ConvertRomanToInteger(string roman)
        {
            Dictionary<char, int> romanDic = new Dictionary<char, int>
            {
                { 'I', 1 },{ 'V', 5 },{'X',10},{'L',50},{'C',100},{'D',500},{ 'M',1000 }
            };
            int total = 0;
            int prev = 0;

            if (roman.Length <= 1)
            {
                return romanDic[roman[0]];
            }
            else
            {

                for (int i = roman.Length - 1; i >= 0; i--)
                {
                    int current = romanDic[roman[i]];


                    if (current < prev)
                    {
                        total -= current;
                    }
                    else
                    {
                        total += current;
                    }
                    prev = current;
                }

                return total;
            }
        }

    }
}
