using PokemonMVVM.DAL;
using PokemonMVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonMVVM.ViewModels
{
    class PokedexViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Pokemon pokemon;

        public Pokemon Pokemon
        {
            get { return pokemon; }
            set
            {
                pokemon = value;
                OnPropertyChanged("pokemon");
                
            }
        }

        public PokedexViewModel() 
        {
            LoadPokemons();
        }

        public async void LoadPokemons()
        {
            Pokemons = await PokemonAPIDAL.LoadPokemons();
            if(Pokemons.Count > 0)
            {
                SelectedPokemon = Pokemons[0];
            }
        }

        private PokemonRef selectedPokemon;
        public PokemonRef SelectedPokemon
        {
            get { return selectedPokemon; }
            set
            {
                selectedPokemon = value;
                OnPropertyChanged("selectedPokemon");

                LoadSinglePokemon();
            }
        }

        public async void LoadSinglePokemon()
        {
            Pokemon = await PokemonAPIDAL.LoadPokemon(SelectedPokemon.Url);
        }

        private List<PokemonRef> pokemons;

        public List<PokemonRef> Pokemons
        {
            get { return pokemons; }
            set
            {
                pokemons = value;
                OnPropertyChanged("pokemons");
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

   
}
