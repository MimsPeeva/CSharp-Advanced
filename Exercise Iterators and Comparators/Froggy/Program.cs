using Froggy;
using System.Runtime;

List<int>list = new List<int>(Console.ReadLine()
   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
   .Select(int.Parse)
   .ToList());
Lake lake = new Lake(list);
string result = string.Join(", ", lake);

    Console.Write(result);
