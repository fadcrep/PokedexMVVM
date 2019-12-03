using Newtonsoft.Json;
using PokemonMVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PokemonMVVM.DAL
{
    class PokemonAPIDAL
    {
        const string LOAD_URL = "https://pokeapi.co/api/v2/pokemon/";

        public static async Task<List<PokemonRef>> LoadPokemons()
        {
            WebClient webClient = new WebClient();
            byte[] data = await webClient.DownloadDataTaskAsync(new Uri(LOAD_URL));
            string json = Encoding.UTF8.GetString(data);
            PokemonAPIResult result = JsonConvert.DeserializeObject<PokemonAPIResult>(json);
            return result.Results;
        }

        public static async Task<Pokemon> LoadPokemon(string url)
        {
            WebClient webClient = new WebClient();
            byte[] data = await webClient.DownloadDataTaskAsync(new Uri(url));
            string json = Encoding.UTF8.GetString(data);
            Pokemon result = JsonConvert.DeserializeObject<Pokemon>(json);
            return result;
        }


    }
}
