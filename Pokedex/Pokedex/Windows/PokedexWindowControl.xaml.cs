//------------------------------------------------------------------------------
// <copyright file="PokedexWindowControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Pokedex.Windows
{
    using Models;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for PokedexWindowControl.
    /// </summary>
    public partial class PokedexWindowControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PokedexWindowControl"/> class.
        /// </summary>
        public PokedexWindowControl()
        {
            this.InitializeComponent();

            List<PokemonModel> items = new List<PokemonModel>();
            items.Add(new PokemonModel() { Name = "Charmander"});
            items.Add(new PokemonModel() { Name = "Bulbasaur"});
            items.Add(new PokemonModel() { Name = "Squirtle"});

            icPokemon.ItemsSource = items;

        }

        /// <summary>
        /// Handles click on the button by displaying a message box.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event args.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Sample code")]
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Default event handler naming pattern")]
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                string.Format(System.Globalization.CultureInfo.CurrentUICulture, "Invoked '{0}'", this.ToString()),
                "PokedexWindow");
        }
    }

}