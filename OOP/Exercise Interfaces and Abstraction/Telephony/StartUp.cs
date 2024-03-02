using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = ReadInput();
            string[] websites = ReadInput();
            CallAllNumbers(phoneNumbers);
            BrowseAllUrls(websites);
        }

        private static void BrowseAllUrls(string[] websites)
        {
            foreach (var url in websites)
            {
                if (IsUrlValid(url))
                {
                    Smartphone phone = new Smartphone();
                    phone.Browse(url);
                }
                else Console.WriteLine("Invalid URL!");
            }
        }

        private static bool IsUrlValid(string url)
        {
          return !url.Any(char.IsDigit);
        }

        private static void CallAllNumbers(string[] phoneNumbers)
        {
            foreach (var number in phoneNumbers)
            {
                ICaller phone;
                if (IsValidNumber(number))
                {
                    if (number.Length == 7)
                    {
                        phone = new StationaryPhone();
                    }
                    else
                    {
                        phone = new Smartphone();
                    }
                    phone.Call(number);
                }
                else Console.WriteLine("Invalid number!");
            }
        }

        private static bool IsValidNumber(string number)
        {
            return number.All(char.IsDigit);
        }

        private static string[] ReadInput()
        { return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
/*
0882134215 0882134333 0899213421 0558123 3333123
http://softuni.bg http://youtube.com http://www.g00gle.com
*/