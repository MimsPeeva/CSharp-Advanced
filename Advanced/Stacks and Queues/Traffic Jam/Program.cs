int carsNumber = int.Parse(Console.ReadLine());
string command = string.Empty;
Queue<string> queue = new Queue<string>();
int passedCars = 0;
while ((command = Console.ReadLine()) != "end")
{
    if (command == "green")
    {
        for (int i = 0; i < carsNumber; i++)
        {
            if (queue.Count > 0)
            {
                string currentCar = queue.Dequeue();
                Console.WriteLine($"{currentCar} passed!");
                passedCars++;
            }
        }
    }
    else 
    {
queue.Enqueue(command);
    }
}
Console.WriteLine($"{passedCars} cars passed the crossroads.");    