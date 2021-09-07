// <copyright file = "DataGridPage.xaml.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace ExecutionInterface.Views
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Controls;
    using Contracts.Views;
    using Core.Contracts.Services;
    using Core.Models;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Page" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="ExecutionInterface.Contracts.Views.INavigationAware" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class DataGridPage : Page, INotifyPropertyChanged, INavigationAware
    {
        /// <summary>
        /// The sample data service
        /// </summary>
        private readonly ISampleDataService _sampleDataService;

        /// <summary>
        /// Gets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public ObservableCollection<SampleOrder> Source { get; } = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridPage"/> class.
        /// </summary>
        /// <param name="sampleDataService">The sample data service.</param>
        public DataGridPage( ISampleDataService sampleDataService )
        {
            _sampleDataService = sampleDataService;
            InitializeComponent();
            DataContext = this;
        }

        /// <summary>
        /// Called when [navigated to].
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public async void OnNavigatedTo( object parameter )
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await _sampleDataService.GetGridDataAsync();

            foreach( var item in data )
            {
                Source.Add( item );
            }
        }

        /// <summary>
        /// Called when [navigated from].
        /// </summary>
        public void OnNavigatedFrom()
        {
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sets the specified storage.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storage">The storage.</param>
        /// <param name="value">The value.</param>
        /// <param name="propertyName">Name of the property.</param>
        private void Set<T>( ref T storage, T value, [ CallerMemberName ] string propertyName = null )
        {
            if( Equals( storage, value ) )
            {
                return;
            }

            storage = value;
            OnPropertyChanged( propertyName );
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void OnPropertyChanged( string propertyName )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}