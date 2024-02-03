namespace Speed_Racing
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Car> carsList = new();
            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = info[0];
                double fuelAmount = double.Parse(info[1]);
                double fuelConsumptionFor1km = double.Parse(info[2]);
                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km,0);
                carsList.Add(model, car);
            }
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] lines = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string carModel = lines[1];
                int amountOfKm = int.Parse(lines[2]);
                Car currentCar = carsList[carModel];
                currentCar.Moving(amountOfKm);
            }
            foreach (var car in carsList.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}