namespace Car_Salesman;
public class startUp
{
    public static void Main()
    {
        int numberOfEngines = int.Parse(Console.ReadLine());
        List<Car> carsList = new List<Car>();
        List<Engine> enginesList = new List<Engine>();
        for (int i = 0; i < numberOfEngines; i++)
        {
            //"{model} {power} {displacement} {efficiency}"
            string[] inputEngine = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Engine engine = CreateEngine(inputEngine);
            enginesList.Add(engine);
         
        }
        int numberOfCars = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCars; i++)
        {
            string[] inputCars = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Car car = CreateCar(inputCars, enginesList);
            carsList.Add(car);
        }
        foreach (var car in carsList)
        {
            Console.WriteLine(car.ToString());
        }
    }

     static Car CreateCar(string[] inputCars, List<Engine> engines)
    {
        string model = inputCars[0];
        Engine engine = engines.Find(car=> car.Model ==inputCars[1]);
        Car car = new Car(model, engine);
        if (inputCars.Length > 2)
        {
            int weight;

            bool isDigit = int.TryParse(inputCars[2], out weight);

            if (isDigit)
            {
                car.Weight = weight;
            }
            else
            {
                car.Color = inputCars[2];
            }

        }
        if (inputCars.Length > 3)
        {
            car.Color = inputCars[3];
        }
        return car;
    }

    static Engine CreateEngine(string[] inputEngine)
    {
        string model = inputEngine[0];
        int power = int.Parse(inputEngine[1]);
        Engine engine = new Engine(model, power);
        if (inputEngine.Length > 2)
        {

            int displacement;

            bool isDigit = int.TryParse(inputEngine[2], out displacement);

            if (isDigit)
            {
                engine.Displacement = displacement;
            }
            else
            {
                engine.Efficiency = inputEngine[2];
            }

        }
        if (inputEngine.Length > 3)
        {
            engine.Efficiency = inputEngine[3];
        }
        return engine;
    }

}
/*
2
V8-101 220 50
V4-33 140 28 B
3
FordFocus V4-33 1300 Silver
FordMustang V8-101
VolkswagenGolf V4-33 Orange
 */