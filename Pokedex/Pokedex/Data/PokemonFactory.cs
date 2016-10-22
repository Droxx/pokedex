using CsvHelper;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Data
{
    public static class PokemonFactory
    {
        public static IEnumerable<PokemonModel> GetPokemon()
        {
            var pokemans = new List<PokemonModel>();
            using (var text = File.OpenText("Data/Pokemon.csv"))
            {
                var csv = new CsvReader(text);
                var pokeMap = new PokemonClassMap();
                csv.Configuration.RegisterClassMap(pokeMap);

                pokemans = csv.GetRecords<PokemonModel>().ToList();
            }

            foreach(var pokemon in pokemans)
            {
                if (String.IsNullOrEmpty(pokemon.Name))
                    throw new ArgumentException("ARGH!");
                pokemon.Name = pokemon.Name.First().ToString().ToUpper() + String.Join("", pokemon.Name.Skip(1));
            }

            return pokemans.Where(p => p.Id <= 151); // Only the first 150 because the rest are terrible
        }
    }
}
