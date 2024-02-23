char[] text = Console.ReadLine()
  .ToCharArray();
SortedDictionary<char, int> dictionary = new SortedDictionary<char, int>();
foreach(char ch in text)
{ 
    if (dictionary.ContainsKey(ch))
    {
        dictionary[ch]++;
    }
    else
    {
        dictionary.Add(ch,1); 
    }
}
foreach (char ch in dictionary.Keys)
{
    Console.WriteLine($"{ch}: {dictionary[ch]} time/s");
}