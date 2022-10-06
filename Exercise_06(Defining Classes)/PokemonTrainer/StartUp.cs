using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
   public class StartUp
    {
        static void Main()
        {
            string input = string.Empty;

            List<Trainer> trainers = new List<Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);
                
                Trainer trainer = trainers.SingleOrDefault(t => t.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                    trainers.Add(trainer);
                }
                else
                {
                    trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }
            }

            string newInput = string.Empty;

            while ((newInput = Console.ReadLine()) != "End")
            {
                string command = newInput;

                PokemoneFilter(trainers, command);
            }
            var sortedTrainer = trainers.OrderByDescending(x => x.BadgesNum);

            foreach (var trainer in sortedTrainer)
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesNum} {trainer.Pokemons.Count}");
            }
        }

        static void PokemoneFilter(List<Trainer> trainers, string command)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(x => x.Element == command))
                {
                    trainer.BadgesNum++;
                }
                else
                {
                    for (int i = 0; i < trainer.Pokemons.Count; i++)
                    {
                        Pokemon curPokemon = trainer.Pokemons[i];
                        curPokemon.Health -= 10;
                        
                        if (curPokemon.Health <= 0)
                        {
                            trainer.Pokemons.Remove(curPokemon);
                        }
                    }
                }
            }
        }
    }
}
