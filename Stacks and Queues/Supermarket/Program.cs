string input = string.Empty;
Queue<string> nameQueue = new Queue<string>();
while ((input = Console.ReadLine()) != "End")
{
    if (input == "Paid")
    {
        while (nameQueue.Count > 0)
        {
            Console.WriteLine(nameQueue.Dequeue());
        }
       
    }
    else 
    {
    nameQueue.Enqueue(input);
    }
}
Console.WriteLine($"{nameQueue.Count} people remaining.");
/*
Liam
Noah
James
Paid
Oliver
Lucas
Logan
Tiana
End
*/