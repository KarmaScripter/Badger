namespace ExecutionInterface.Activation
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows;
    using Microsoft.Extensions.Configuration;
    using Contracts.Activation;
    using Contracts.Services;
    using Contracts.Views;

    // For more information about sending a local toast notification from C# apps, see
    // https://docs.microsoft.com/windows/uwp/design/shell/tiles-and-notifications/send-local-toast?tabs=desktop
    // and https://github.com/microsoft/WindowsTemplateStudio/blob/release/docs/WPF/features/toast-notifications.md
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ExecutionInterface.Contracts.Activation.IActivationHandler" />
    public class ToastNotificationActivationHandler : IActivationHandler
    {
        /// <summary>
        /// The activation arguments
        /// </summary>
        public const string ActivationArguments = "ToastNotificationActivationArguments";

        /// <summary>
        /// The configuration
        /// </summary>
        private readonly IConfiguration _config;

        /// <summary>
        /// The service provider
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// The navigation service
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="ToastNotificationActivationHandler" /> class.
        /// </summary>
        /// <param name="config">
        /// The configuration.
        /// </param>
        /// <param name="serviceProvider">
        /// The service provider.
        /// </param>
        /// <param name="navigationService">
        /// The navigation service.
        /// </param>
        public ToastNotificationActivationHandler( IConfiguration config,
            IServiceProvider serviceProvider, INavigationService navigationService )
        {
            _config = config;
            _serviceProvider = serviceProvider;
            _navigationService = navigationService;
        }

        /// <summary>
        /// Determines whether this instance can handle.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance can handle; otherwise, <c>false</c>.
        /// </returns>
        public bool CanHandle()
        {
            return !string.IsNullOrEmpty( _config[ ToastNotificationActivationHandler.ActivationArguments ] );
        }

        /// <summary>
        /// Handles the asynchronous.
        /// </summary>
        public async Task HandleAsync()
        {
            if( App.Current.Windows.OfType<IShellWindow>().Count() == 0 )
            {
                // Here you can get an instance of the ShellWindow and choose navigate
                // to a specific page depending on the toast notification arguments
            }
            else
            {
                App.Current.MainWindow.Activate();

                if( App.Current.MainWindow.WindowState == WindowState.Minimized )
                {
                    App.Current.MainWindow.WindowState = WindowState.Normal;
                }
            }

            await Task.CompletedTask;
        }
    }
}