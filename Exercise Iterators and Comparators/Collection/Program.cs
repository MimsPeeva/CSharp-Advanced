namespace Collection;
public class StarUp
{
    public static void Main()
    {
        string[] lines = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        ListyIterator<string> list = new ListyIterator<string>(lines.Skip(1).ToList());
        string command = string.Empty;
        while ((command = Console.ReadLine()) != "END")
        {
            if (command == "Move")
            {
                if (list.Move() == true)
                {
                    Console.WriteLine("True");
                }
                else Console.WriteLine("False");
            }
            else if (command == "HasNext")
            {
                if (list.HasNext() == true)
                {
                    Console.WriteLine("True");
                }
                else Console.WriteLine("False");

            }

            else if (command == "Print")
            {
                try

                {
                    list.Print();
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine("Invalid Operation!");
                }
            }
            else if (command == "PrintAll")
            {
                list.PrintAll();
            }
        }
    }
}