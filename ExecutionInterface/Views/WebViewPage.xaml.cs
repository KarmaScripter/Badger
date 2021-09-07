// <copyright file = "WebViewPage.xaml.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace ExecutionInterface.Views
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Windows.Controls;
    using Contracts.Services;
    using Contracts.Views;
    using Microsoft.Web.WebView2.Core;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Windows.Controls.Page" />
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    /// <seealso cref="ExecutionInterface.Contracts.Views.INavigationAware" />
    /// <seealso cref="System.Windows.Markup.IComponentConnector" />
    public partial class WebViewPage : Page, INotifyPropertyChanged, INavigationAware
    {
        // TODO WTS: Set the URI of the page to show by default
        /// <summary>
        /// The default URL
        /// </summary>
        private const string _defaultUrl = "https://docs.microsoft.com/windows/apps/";

        /// <summary>
        /// The system service
        /// </summary>
        private readonly ISystemService _systemService;

        /// <summary>
        /// The source
        /// </summary>
        private string _source;

        /// <summary>
        /// The is loading
        /// </summary>
        private bool _isLoading = true;

        /// <summary>
        /// The is showing failed message
        /// </summary>
        private bool _isShowingFailedMessage;

        /// <summary>
        /// The can browser back
        /// </summary>
        private bool _canBrowserBack;

        /// <summary>
        /// The can browser forward
        /// </summary>
        private bool _canBrowserForward;

        /// <summary>
        /// The is loading visibility
        /// </summary>
        private Visibility _isLoadingVisibility = Visibility.Visible;

        /// <summary>
        /// The failed mesage visibility
        /// </summary>
        private Visibility _failedMesageVisibility = Visibility.Collapsed;

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>
        /// The source.
        /// </value>
        public string Source
        {
            get { return _source; }
            set { Set( ref _source, value ); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is loading.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is loading; otherwise, <c>false</c>.
        /// </value>
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

        /// <summary>
        /// Gets or sets a value indicating whether this instance is showing failed message.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is showing failed message; otherwise, <c>false</c>.
        /// </value>
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

        /// <summary>
        /// Gets or sets a value indicating whether this instance can browser back.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can browser back; otherwise, <c>false</c>.
        /// </value>
        public bool CanBrowserBack
        {
            get { return _canBrowserBack; }
            set { Set( ref _canBrowserBack, value ); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance can browser forward.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can browser forward; otherwise, <c>false</c>.
        /// </value>
        public bool CanBrowserForward
        {
            get { return _canBrowserForward; }
            set { Set( ref _canBrowserForward, value ); }
        }

        /// <summary>
        /// Gets or sets the is loading visibility.
        /// </summary>
        /// <value>
        /// The is loading visibility.
        /// </value>
        public Visibility IsLoadingVisibility
        {
            get { return _isLoadingVisibility; }
            set { Set( ref _isLoadingVisibility, value ); }
        }

        /// <summary>
        /// Gets or sets the failed mesage visibility.
        /// </summary>
        /// <value>
        /// The failed mesage visibility.
        /// </value>
        public Visibility FailedMesageVisibility
        {
            get { return _failedMesageVisibility; }
            set { Set( ref _failedMesageVisibility, value ); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebViewPage"/> class.
        /// </summary>
        /// <param name="systemService">The system service.</param>
        public WebViewPage( ISystemService systemService )
        {
            _systemService = systemService;
            Source = WebViewPage._defaultUrl;
            InitializeComponent();
            DataContext = this;
        }

        /// <summary>
        /// Called when [navigated to].
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        public void OnNavigatedTo( object parameter )
        {
        }

        /// <summary>
        /// Called when [navigated from].
        /// </summary>
        public void OnNavigatedFrom()
        {
        }

        /// <summary>
        /// Called when [browser back].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnBrowserBack( object sender, RoutedEventArgs e )
        {
            webView2.GoBack();
        }

        /// <summary>
        /// Called when [browser forward].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnBrowserForward( object sender, RoutedEventArgs e )
        {
            webView2.GoForward();
        }

        /// <summary>
        /// Called when [refresh].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnRefresh( object sender, RoutedEventArgs e )
        {
            IsShowingFailedMessage = false;
            IsLoading = true;
        }

        /// <summary>
        /// Called when [open in browser].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnOpenInBrowser( object sender, RoutedEventArgs e )
        {
            _systemService.OpenInWebBrowser( Source );
        }

        /// <summary>
        /// Called when [navigation completed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="coreWebView2NavigationCompletedEventArgs">The <see cref="CoreWebView2NavigationCompletedEventArgs"/> instance containing the event data.</param>
        private void OnNavigationCompleted( object sender,
            CoreWebView2NavigationCompletedEventArgs coreWebView2NavigationCompletedEventArgs )
        {
            IsLoading = false;

            if( sender != null )
            {
                // Use `e.WebErrorStatus` to vary the displayed message based on the error reason
                IsShowingFailedMessage = true;
            }

            CanBrowserBack = webView2.CanGoBack;
            CanBrowserForward = webView2.CanGoForward;
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