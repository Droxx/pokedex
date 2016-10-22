using Pokedex.Data;
using Pokedex.Models;
using PokedexAnalyzer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace Pokedex.ViewModels
{
    public class PokemonViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<PokemonModel> Pokemon;

        private ObservableCollection<PokemonModel> _items;
        public ObservableCollection<PokemonModel> Items
        {
            get { return _items; }
            set
            {
                if (_items == value)
                { return; }
                _items = value;
                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Items"));
            }
        }

        public PokemonViewModel()
        {
            Pokemon = PokemonFactory.GetPokemon().ToList();
            Items = new ObservableCollection<PokemonModel>();
        }

        public void Tick(object sender, EventArgs e)
        {
            var caughtPmans = CaughtArray.GetCaughtPokemon();

            bool changed = false;

            foreach (var model in Pokemon)
            {
                var caught = caughtPmans.Contains(model.Name);
                if (model.Caught != caught)
                {
                    changed = true;
                }

                model.Caught = caught;
            }

            if (changed)
            {
                Items = new ObservableCollection<PokemonModel>(Pokemon.Where(p => p.Caught).ToList()); ;
                //foreach(var pokemon in Pokemon)
                //{

                //}

                //// BECAUSE FUCK THE PROPERTY CHANGED NOTIFIERS
                //int count = Items.Count;
                //for(int i = 0; i < count; i++)
                //{
                //    var item = Items[0];
                //    Items.Remove(item);
                //    Items.Add(item);
                //}

                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Items"));
            }
        }
    }
}
