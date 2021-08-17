namespace ExecutionInterface.Views
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;
    using Contracts.Services;
    using Contracts.Views;

    public partial class WebViewPage : Page, INotifyPropertyChanged, INavigationAware
    {
        // TODO WTS: Set the URI of the page to show by default
        private const string _defaultUrl = "https://docs.microsoft.com/windows/apps/";

        private readonly ISystemService _systemService;

        private string _source;

        private bool _isLoading = true;

        private bool _isShowingFailedMessage;

        private bool _canBrowserBack;

        private bool _canBrowserForward;

        private Visibility _isLoadingVisibility = Visibility.Visible;

        private Visibility _failedMesageVisibility = Visibility.Collapsed;

        public string Source
        {
            get { return _source; }
            set { Set( ref _source, value ); }
        }

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                Set( ref _isLoading, value );

                IsLoadingVisibility = value
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
        }

        public bool IsShowingFailedMessage
        {
            get
            {
                return _isShowingFailedMessage;
            }
            set
            {
                Set( ref _isShowingFailedMessage, value );

                FailedMesageVisibility = value
                    ? Visibility.Visible
                    : Visibility.Collapsed;
            }
        }

        public bool CanBrowserBack
        {
            get { return _canBrowserBack; }
            set { Set( ref _canBrowserBack, value ); }
        }

        public bool CanBrowserForward
        {
            get { return _canBrowserForward; }
            set { Set( ref _canBrowserForward, value ); }
        }

        public Visibility IsLoadingVisibility
        {
            get { return _isLoadingVisibility; }
            set { Set( ref _isLoadingVisibility, value ); }
        }

        public Visibility FailedMesageVisibility
        {
            get { return _failedMesageVisibility; }
            set { Set( ref _failedMesageVisibility, value ); }
        }

        public WebViewPage( ISystemService systemService )
        {
            _systemService = systemService;
            Source = WebViewPage._defaultUrl;
            InitializeComponent();
            DataContext = this;
        }

        public void OnNavigatedTo( object parameter )
        {
        }

        public void OnNavigatedFrom()
        {
        }

        private void OnBrowserBack( object sender, RoutedEventArgs e )
        {
            webView.GoBack();
        }

        private void OnBrowserForward( object sender, RoutedEventArgs e )
        {
            webView.GoForward();
        }

        private void OnRefresh( object sender, RoutedEventArgs e )
        {
            IsShowingFailedMessage = false;
            IsLoading = true;
            webView.Refresh();
        }

        private void OnOpenInBrowser( object sender, RoutedEventArgs e )
        {
            _systemService.OpenInWebBrowser( Source );
        }

        private void OnNavigationCompleted( object sender,
            WebViewControlNavigationCompletedEventArgs e )
        {
            IsLoading = false;

            if( e != null
                && !e.IsSuccess )
            {
                // Use `e.WebErrorStatus` to vary the displayed message based on the error reason
                IsShowingFailedMessage = true;
            }

            CanBrowserBack = webView.CanGoBack;
            CanBrowserForward = webView.CanGoForward;
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