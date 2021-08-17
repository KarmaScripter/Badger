// <copyright file="MenuItemTemplateSelector.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace ExecutionInterface.TemplateSelectors
{
    using System.Windows;
    using System.Windows.Controls;
    using MahApps.Metro.Controls;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Controls.DataTemplateSelector" />
    public class MenuItemTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the glyph data template.
        /// </summary>
        /// <value>
        /// The glyph data template.
        /// </value>
        public DataTemplate GlyphDataTemplate { get; set; }

        /// <summary>
        /// Gets or sets the image data template.
        /// </summary>
        /// <value>
        /// The image data template.
        /// </value>
        public DataTemplate ImageDataTemplate { get; set; }

        /// <summary>
        /// When overridden in a derived class, returns a <see cref="T:System.Windows.DataTemplate" /> based on custom logic.
        /// </summary>
        /// <param name="item">The data object for which to select the template.</param>
        /// <param name="container">The data-bound object.</param>
        /// <returns>
        /// Returns a <see cref="T:System.Windows.DataTemplate" /> or <see langword="null" />. The default value is <see langword="null" />.
        /// </returns>
        public override DataTemplate SelectTemplate( object item, DependencyObject container )
        {
            if( item is HamburgerMenuGlyphItem )
            {
                return GlyphDataTemplate;
            }

            if( item is HamburgerMenuImageItem )
            {
                return ImageDataTemplate;
            }

            return base.SelectTemplate( item, container );
        }
    }
}