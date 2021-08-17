namespace ExecutionInterface.Services
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using MahApps.Metro.Controls;
    using Contracts.Services;
    using Contracts.Views;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ExecutionInterface.Contracts.Services.IWindowManagerService" />
    public class WindowManagerService : IWindowManagerService
    {
        /// <summary>
        /// The service provider
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Gets the main window.
        /// </summary>
        /// <value>
        /// The main window.
        /// </value>
        public Window MainWindow
        {
            get
            {
                return Application.Current.MainWindow;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowManagerService"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public WindowManagerService( IServiceProvider serviceProvider )
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Opens the in new window.
        /// </summary>
        /// <param name="pageType">Type of the page.</param>
        /// <param name="parameter">The parameter.</param>
        public void OpenInNewWindow( Type pageType, object parameter = null )
        {
            var window = GetWindow( pageType );

            if( window != null )
            {
                window.Activate();
            }
            else
            {
                window = new MetroWindow()
                {
                    Title = "ExecutionInterface",
                    Style = Application.Current.FindResource( "CustomMetroWindow" ) as Style
                };

                var frame = new Frame()
                {
                    Focusable = false,
                    NavigationUIVisibility = NavigationUIVisibility.Hidden
                };

                window.Content = frame;
                window.Closed += OnWindowClosed;
                window.Show();
                frame.Navigated += OnNavigated;
                var page = _serviceProvider.GetService( pageType );
                var navigated = frame.Navigate( page, parameter );
            }
        }

        /// <summary>
        /// Opens the in dialog.
        /// </summary>
        /// <param name="pageType">Type of the page.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        public bool? OpenInDialog( Type pageType, object parameter = null )
        {
            var shellWindow = _serviceProvider.GetService( typeof( IShellDialogWindow ) ) as Window;
            var frame = ( (IShellDialogWindow)shellWindow ).GetDialogFrame();
            frame.Navigated += OnNavigated;
            shellWindow.Closed += OnWindowClosed;
            var page = _serviceProvider.GetService( pageType );
            var navigated = frame.Navigate( page, parameter );
            return shellWindow.ShowDialog();
        }

        /// <summary>
        /// Gets the window.
        /// </summary>
        /// <param name="pageType">Type of the page.</param>
        /// <returns></returns>
        public Window GetWindow( Type pageType )
        {
            foreach( Window window in Application.Current.Windows )
            {
                if( window.Content is Frame frame )
                {
                    if( frame.Content.GetType() == pageType )
                    {
                        return window;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Called when [navigated].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
        private void OnNavigated( object sender, NavigationEventArgs e )
        {
            if( sender is Frame frame )
            {
                var page = frame.Content;

                if( page is INavigationAware navigationAware )
                {
                    navigationAware.OnNavigatedTo( e.ExtraData );
                }
            }
        }

        /// <summary>
        /// Called when [window closed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnWindowClosed( object sender, EventArgs e )
        {
            if( sender is Window window )
            {
                if( window.Content is Frame frame )
                {
                    frame.Navigated -= OnNavigated;
                }

                window.Closed -= OnWindowClosed;
            }
        }
    }
}