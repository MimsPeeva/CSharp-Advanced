string[] input = Console.ReadLine()
    .Split(", ");
Queue<string> playlist = new Queue<string>(input);
if (playlist.Any())
{ }
while ((playlist.Any()))
{
    string[] command = Console.ReadLine().Split();
    if (command[0] == "Play")
    {
        playlist.Dequeue();
    }
    else if (command[0] == "Add")
    {
        string song = string.Join(" ", command.Skip(1));
        if (playlist.Contains(song))
        {
            Console.WriteLine($"{song} is already contained!");
        }
        else
        {
            playlist.Enqueue(song);
        }
    }
    else if (command[0] == "Show")
    {
        Console.WriteLine(string.Join(", ", playlist));
    }
}
Console.WriteLine("No more songs!");
/*
All Over Again, Watch Me
Play
Add Watch Me
Add Love Me Harder
Add Promises
Show
Play
Play
Play
Play
 */