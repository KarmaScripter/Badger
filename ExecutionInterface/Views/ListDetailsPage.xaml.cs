namespace ExecutionInterface.Views
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Controls;
    using Contracts.Views;
    using Core.Contracts.Services;
    using Core.Models;

    public partial class ListDetailsPage : Page, INotifyPropertyChanged, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;

        private SampleOrder _selected;

        public SampleOrder Selected
        {
            get { return _selected; }
            set { Set( ref _selected, value ); }
        }

        public ObservableCollection<SampleOrder> SampleItems { get; } = new();

        public ListDetailsPage( ISampleDataService sampleDataService )
        {
            _sampleDataService = sampleDataService;
            InitializeComponent();
            DataContext = this;
        }

        public async void OnNavigatedTo( object parameter )
        {
            SampleItems.Clear();

            var data = await _sampleDataService.GetListDetailsDataAsync();

            foreach( var item in data )
            {
                SampleItems.Add( item );
            }

            Selected = SampleItems.First();
        }

        public void OnNavigatedFrom()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Set<T>( ref T storage, T value, [ CallerMemberName ]
            string propertyName = null )
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