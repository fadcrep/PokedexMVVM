using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonMVVM.Models

    
{

    public class PokemonAPIResult
    {
        public List<PokemonRef> Results;
    }
    class Pokemon
    {
        public Sprite Sprites { get; set; }
    }

    public class PokemonRef
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Sprite
    {
        public string Front_default { get; set; }
    }
}
