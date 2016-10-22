//------------------------------------------------------------------------------
// <copyright file="PokedexWindowControl.xaml.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Pokedex.Windows
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;
    using PokedexAnalyzer;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using ViewModels;/// <summary>
                     /// Interaction logic for PokedexWindowControl.
                     /// </summary>
    public partial class PokedexWindowControl : UserControl
    {
        PokemonViewModel pvm = new PokemonViewModel();
        /// <summary>
        /// Initializes a new instance of the <see cref="PokedexWindowControl"/> class.
        /// </summary>
        public PokedexWindowControl()
        {
            this.InitializeComponent();
            icPokemon.DataContext = pvm;

            DispatcherTimer dt = new DispatcherTimer();
            dt.Tick += new EventHandler(pvm.Tick);
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Start();
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