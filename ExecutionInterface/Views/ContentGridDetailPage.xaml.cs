namespace ExecutionInterface.Views
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Controls;
    using Contracts.Views;
    using Core.Contracts.Services;
    using Core.Models;

    public partial class ContentGridDetailPage : Page, INotifyPropertyChanged, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;

        private SampleOrder _item;

        public SampleOrder Item
        {
            get { return _item; }
            set { Set( ref _item, value ); }
        }

        public ContentGridDetailPage( ISampleDataService sampleDataService )
        {
            _sampleDataService = sampleDataService;
            InitializeComponent();
            DataContext = this;
        }

        public async void OnNavigatedTo( object parameter )
        {
            if( parameter is long orderID )
            {
                var data = await _sampleDataService.GetContentGridDataAsync();
                Item = data.First( i => i.OrderID == orderID );
            }
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