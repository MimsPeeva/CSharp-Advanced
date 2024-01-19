string input = string.Empty;
HashSet<string> VIP = new HashSet<string>();
HashSet<string> Regular = new HashSet<string>();
while ((input = Console.ReadLine()) != "PARTY")
{
    char firstChar = input[0];
    if (char.IsDigit(firstChar))
    {
        if (!VIP.Contains(input))
        {
            VIP.Add(input);
        }
    }
    else 
    {
       if (!Regular.Contains(input))
       {
            Regular.Add(input); 
       }
    }
}
while ((input = Console.ReadLine()) != "END")
{
    if (VIP.Contains(input))
    { 
        VIP.Remove(input); 
    }
    else if (Regular.Contains(input))
    { 
        Regular.Remove(input);
    }
}
int countinputsDidNotCome = VIP.Count + Regular.Count;
Console.WriteLine(countinputsDidNotCome);
if (VIP.Count > 0)
{ Console.WriteLine(string.Join("\n", VIP)); }
 if (Regular.Count > 0)
{ Console.WriteLine(string.Join("\n", Regular)); }
/*
7IK9Yo0h
9NoBUajQ
Ce8vwPmE
SVQXQCbc
tSzE5t0p
PARTY
9NoBUajQ
Ce8vwPmE
SVQXQCbc
END
 */