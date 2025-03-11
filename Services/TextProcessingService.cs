using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BluebikTest.Interfaces;

namespace BluebikTest.Services
{
    public class TextProcessingService : ITextProcessingService
    {

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

    }
}
