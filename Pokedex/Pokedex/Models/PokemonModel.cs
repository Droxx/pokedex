using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    class PokemonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TypeModel> Types { get; set; }
        public double MaxHeight { get; set; }
        public double MinHeight { get; set; }
        public double MaxWeight { get; set; }
        public double MinWeight { get; set; }
        
        // MIDI Cry?
        // How to get icon 
    }
}
