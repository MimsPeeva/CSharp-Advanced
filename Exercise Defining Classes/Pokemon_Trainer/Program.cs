using System.Diagnostics.Metrics;
using System.Globalization;

namespace Pokemon_Trainer;
public class startUp
{
    public static void Main()
    {
        string input = string.Empty;
        List<Trainer> trainerList = new();
        List<Pokemon> pokemonList = new();

        while ((input = Console.ReadLine()) != "Tournament")
        {
            string[] lines = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string trainerName = lines[0];
            string pokemonName = lines[1];
            string pokemonElement = lines[2];
            int pokemonHealth = int.Parse(lines[3]);
            Pokemon currPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
            pokemonList.Add(currPokemon);
            Trainer currTrainer = trainerList.SingleOrDefault(t => t.Name == trainerName);
         
            if (currTrainer == null)
            {
                trainerList.Add(CreateTrainer(trainerName, 0, (CreatePokemon(pokemonName, pokemonElement, pokemonHealth))));
            }
            else
            {
                currTrainer.Pokemon.Add(currPokemon);
            }
        }

        string command = string.Empty;
        while ((command = Console.ReadLine()) != "End")
        {
            //if (command == "Fire")
            //{

            //}
            //else if (command == "Water")
            //{ 

            //}
            //else if (command == "Electricity")
            //{
           
            foreach (Trainer trainer in trainerList)
            {
                trainer.CheckPokemon(command);
            }
        }
      
        trainerList.OrderByDescending(x => x.NumberOfBadges)
            .ToList().ForEach(x => Console.WriteLine($"{x.Name} {x.NumberOfBadges} {x.Pokemon.Count}"));
    }
    static Pokemon CreatePokemon(string name, string element, int health)
    {
        Pokemon pokemon = new Pokemon(name, element, health);
        return pokemon;
    }
    static Trainer CreateTrainer(string name, int badges, Pokemon pokemon)
    {
        List<Pokemon> pokemons = new List<Pokemon>();
        pokemons.Add(pokemon);
        Trainer trainer = new Trainer(name, badges, pokemons);
        return trainer;
    }
}
/*
Peter Charizard Fire 100
George Squirtle Water 38
Peter Pikachu Electricity 10
Tournament
Fire
Electricity
End

Sam Blastoise Water 18
Narry Pikachu Electricity 22
John Kadabra Psychic 90
Tournament
Fire
Electricity
Fire
End
 */