using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Models
{
    public class TypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<TypeModel> StrongAgainst { get; set; }
        public IEnumerable<TypeModel> WeakAgainst { get; set; }
    }
}
