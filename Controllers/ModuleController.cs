using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BluebikTest.Interfaces;

namespace BluebikTest.Controllers
{
    public class ModuleController
    {
        private readonly ITextProcessingService textService;
        private readonly INumberConvertsionService convertRomanService;
        private readonly INumberPairService numberPairService;
        public ModuleController(ITextProcessingService textService, INumberConvertsionService convertRomanService, INumberPairService numberPairService)
        {
            this.textService = textService;
            this.convertRomanService = convertRomanService;
            this.numberPairService = numberPairService;
        }

        public void FindMostCommonWord()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Module Find most common word");
                Console.WriteLine("Please enter the text to identify the most common word  or type 'exit' or 'quit' to go back to the menu...\n");
                string text = Console.ReadLine();
                if (ExitToManu(text))
                {
                    break; // ออกจากลูปและกลับไปที่เมนูหลัก
                }
                try
                {
                    if (text.Length == 0)
                    {
                        throw new Exception("Input must not be null or empty");
                    }
                    // ตรวจสอบหากผู้ใช้กรอกคำว่า "exit" หรือ "quit"
                    if (ExitToManu(text))
                    {
                        Console.WriteLine("Exiting to main menu...");
                        break; // ออกจากลูปและกลับไปที่เมนูหลัก
                    }

                    string result = textService.FindMostCommonWord(text);
                    Console.WriteLine("OUTPUT : " + result);

                    Console.WriteLine("\nPress Enter to try again, or type 'exit' or 'quit' to go back to the menu...");
                    string enter = Console.ReadLine(); // รอให้ผู้ใช้กด Enter หรือกรอกคำว่า "exit" หรือ "quit"

                    // ถ้าผู้ใช้กรอก "exit" หรือ "quit" ก็จะออกจากลูป
                    if (ExitToManu(enter))
                    {
                        break; // ออกจากลูปและกลับไปที่เมนูหลัก
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                    continue;
                }
            }
        }
        public void ConvertRomanToInteger()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Module convert roman to integer");
                Console.WriteLine("Enter roman number  or type 'exit' or 'quit' to go back to the menu...\n");



                string romanFormat = Console.ReadLine().ToUpper();

                if (ExitToManu(romanFormat))
                {
                    break;
                }
                if (romanFormat.Length == 0)
                {
                    Console.WriteLine("Invalid format");
                    Console.WriteLine("Please enter to continute...");
                    Console.ReadLine();
                    continue;
                }
                bool validFormat = Regex.Match(romanFormat, @"^M{0,4}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$").Success;
                if (!validFormat)
                {
                    Console.WriteLine(romanFormat + " Is invalid format ");
                    Console.WriteLine("Please enter to continute...");
                    Console.ReadLine();
                    continue;
                }

                int result = convertRomanService.ConvertRomanToInteger(romanFormat);
                Console.WriteLine($"OUTPUT : {romanFormat} => {result}");
                Console.WriteLine("\nPress Enter to try again, or type 'exit' or 'quit' to go back to the menu...");
                if (ExitToManu(Console.ReadLine()!))
                {
                    break;
                }

            }
        }
        public void FindPairs()
        {
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Module Find pairs");
                    Console.WriteLine("Enter a list of number separated by commas (e.g 1, 2, 3, 4), or type 'exit' or 'quit' to go back to the menu...\n");
                    string input = Console.ReadLine();

                    if (ExitToManu(input))
                    {
                        break; // ออกจากลูปและกลับไปที่เมนูหลัก
                    }


                    Console.WriteLine("Enter the target sum: ");
                    int target = int.Parse(Console.ReadLine().Trim());

                    int[] inputListNum = input.Split(",").Select(x => int.Parse(x.Trim())).ToArray();

                    string result = numberPairService.FindPairs(inputListNum, target);
                    Console.WriteLine($"OUTPUT : {result}");

                    Console.WriteLine("\nPress Enter to try again, or type 'exit' or 'quit' to go back to the menu...");
                    string enter = Console.ReadLine()!;

                    // ถ้าผู้ใช้กรอก "exit" หรือ "quit" ก็จะออกจากลูป
                    if (ExitToManu(enter))
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    continue;
                }
            }

        }

        private bool ExitToManu(string check)
        {
            if (check.ToLower() == "exit" || check.ToLower() == "quit")
            {
                Console.WriteLine("Exiting to main menu...");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
