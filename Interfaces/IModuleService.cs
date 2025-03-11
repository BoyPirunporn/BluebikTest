using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluebikTest.Interfaces
{
    public interface IModuleService
    {
        string FindMostCommonWord(string text);
        int ConvertRomanToInteger(string roman);

        string FindPairs(int[] input, int target);
    }
}
