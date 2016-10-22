using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexAnalyzer
{
    public static class CaughtArray
    {
        private static List<string> CaughtPNames = new List<string>();

        public static void AmmendList(string name)
        {
            if (!CaughtPNames.Any(n => n == name))
            {
                CaughtPNames.Add(name);
            }
        }

        public static List<string> GetCaughtPokemon()
        {
            return CaughtPNames;
        }
    }
}
