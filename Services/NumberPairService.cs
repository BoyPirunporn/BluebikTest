using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BluebikTest.Interfaces;

namespace BluebikTest.Services
{
    public class NumberPairService : INumberPairService
    {
        public string FindPairs(int[] input, int target)
        {
            List<(int, int)> pairs = new List<(int, int)>();
            for (int i = 0; i < input.Length - 1; i++)
            {
                int first = input[i];
                int sec = input[i + 1];
                if ((first + sec) == target)
                {
                    pairs.Add((first, sec));
                }
            }

            string result = "[" + string.Join(", ", pairs.Select(p => $"({p.Item1},{p.Item2})")) + "]";
            return result;
        }

    }
}
