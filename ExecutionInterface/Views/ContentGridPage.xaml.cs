// <copyright file = "ContentGridPage.xaml.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace ExecutionInterface.Views
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Contracts.Services;
    using Contracts.Views;
    using Core.Contracts.Services;
    using Core.Models;

    public partial class ContentGridPage : Page, INotifyPropertyChanged, INavigationAware
    {
        private readonly INavigationService _navigationService;

        private readonly ISampleDataService _sampleDataService;

        public ObservableCollection<SampleOrder> Source { get; } = new();

        public ContentGridPage( INavigationService navigationService, ISampleDataService sampleDataService )
        {
            _navigationService = navigationService;
            _sampleDataService = sampleDataService;
            InitializeComponent();
            DataContext = this;
        }

        public async void OnNavigatedTo( object parameter )
        {
            Source.Clear();

            // Replace this with your actual data
            var data = await _sampleDataService.GetContentGridDataAsync();

            foreach( var item in data )
            {
                Source.Add( item );
            }
        }

        public void OnNavigatedFrom()
        {
        }

        private void OnPreviewMouseLeftButtonDown( object sender, MouseButtonEventArgs e )
        {
            SelectItem( e );
        }

        private void OnKeyDown( object sender, KeyEventArgs e )
        {
            if( e.Key == Key.Enter )
            {
                SelectItem( e );
                e.Handled = true;
            }
        }

        private void SelectItem( RoutedEventArgs args )
        {
            if( args.OriginalSource is FrameworkElement selectedItem
                && selectedItem.DataContext is SampleOrder order )
            {
                _navigationService.NavigateTo( typeof( ContentGridDetailPage ), order.OrderID );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>( ref T storage, T value, [ CallerMemberName ] string propertyName = null )
        {
            if( Equals( storage, value ) )
            {
                return;
            }

            storage = value;
            OnPropertyChanged( propertyName );
        }

        private void OnPropertyChanged( string propertyName )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
        }
    }
}