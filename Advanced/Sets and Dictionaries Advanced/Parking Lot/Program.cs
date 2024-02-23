string input = string.Empty;
HashSet<string> carsList = new HashSet<string>();
while ((input = Console.ReadLine()) != "END")
{
    string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
    string command = tokens[0];
    string number = tokens[1];
    if (command == "IN")
    { carsList.Add(number); }
   else if (command == "OUT")
    { carsList.Remove(number); }
}
if (carsList.Count == 0)
{ Console.WriteLine("Parking Lot is Empty"); }
else
    Console.WriteLine(string.Join("\n", carsList));
