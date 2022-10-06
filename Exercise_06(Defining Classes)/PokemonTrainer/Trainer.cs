using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
            BadgesNum = 0;
        }
        //public Trainer(string name, int badgesNum, List<Pokemon> pokemons):this()
        //{
        //    Name = name;
        //    BadgesNum = badgesNum;
        //    Pokemons = pokemons;
        //}
        public string Name { get; set; }
        public int BadgesNum { get; set; }
        public List<Pokemon> Pokemons { get; set; }

    }
}
