using Generic_Box_of_Integer;

int n = int.Parse(Console.ReadLine());
Box<int> box = new Box<int>();
for (int i = 0; i < n; i++)
{
    int input = int.Parse(Console.ReadLine());
    box.AddItem(input);
}
Console.WriteLine(box);