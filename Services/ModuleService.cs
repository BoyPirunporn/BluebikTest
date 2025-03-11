using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BluebikTest.Interfaces;

namespace BluebikTest.Services
{
    public class ModuleService : IModuleService
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

        public string FindMostCommonWord(string text)
        {
            string[] wordArr = Regex.Replace(text, "[.,!?]", "").ToLower().Split(" ");

            Dictionary<string, int> results = new Dictionary<string, int> { };
            foreach (string word in wordArr)
            {
                if (results.ContainsKey(word))
                {
                    results[word]++;
                }
                else
                {
                    results.Add(word, 1);
                }
            }
            int maxInt = int.MinValue;
            string mostWord = "";
            foreach (string word in results.Keys)
            {
                if (maxInt < results[word])
                {
                    maxInt = results[word];
                    mostWord = word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
                }
            }

            return $"Found \"{mostWord}\" {maxInt} time(s)";
        }

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
