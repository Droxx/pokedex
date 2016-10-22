using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class PokemonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TypeModel> Types { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public bool Caught { get; set; }

        public string DisplayFontWeight { get { return Caught ? "Bold" : "Normal"; } }

        // MIDI Cry?
        public string Img { get { return $"/Pokedex;component/Imges/{Id}.png"; } }
    }
}
