using CsvHelper.Configuration;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Data
{
    public sealed class PokemonClassMap : CsvClassMap<PokemonModel>
    {
        public PokemonClassMap()
        {
            Map(m => m.Id).Name("id");
            Map(m => m.Name).Name("identifier");
            Map(m => m.Description).Ignore();
            Map(m => m.Types).Ignore();
            Map(m => m.Height).Name("height");
            Map(m => m.Weight).Name("weight");
        }
    }
}
