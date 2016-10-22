//------------------------------------------------------------------------------
// <copyright file="PokedexWindow.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Pokedex.Windows
{
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.VisualStudio.Shell;
    using System.Collections.Generic;
    /// <summary>
    /// This class implements the tool window exposed by this package and hosts a user control.
    /// </summary>
    /// <remarks>
    /// In Visual Studio tool windows are composed of a frame (implemented by the shell) and a pane,
    /// usually implemented by the package implementer.
    /// <para>
    /// This class derives from the ToolWindowPane class provided from the MPF in order to use its
    /// implementation of the IVsUIElementPane interface.
    /// </para>
    /// </remarks>
    [Guid("05ad1ac7-36b7-4712-aa7a-0cf367aada35")]
    public class PokedexWindow : ToolWindowPane
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PokedexWindow"/> class.
        /// </summary>
        public PokedexWindow() : base(null)
        {
            this.Caption = "Pokedex";

            // This is the user control hosted by the tool window; Note that, even if this class implements IDisposable,
            // we are not calling Dispose on this object. This is because ToolWindowPane calls Dispose on
            // the object returned by the Content property.
            this.Content = new PokedexWindowControl();

        }
    }
}
