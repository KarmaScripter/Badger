namespace ExecutionInterface.Services
{
    using Microsoft.Toolkit.Uwp.Notifications;
    using Contracts.Services;
    using Windows.UI.Notifications;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ExecutionInterface.Contracts.Services.IToastNotificationsService" />
    public partial class ToastNotificationsService : IToastNotificationsService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ToastNotificationsService"/> class.
        /// </summary>
        public ToastNotificationsService()
        {
        }

        /// <summary>
        /// Shows the toast notification.
        /// </summary>
        /// <param name="toastNotification">The toast notification.</param>
        public void ShowToastNotification( ToastNotification toastNotification )
        {
            ToastNotificationManagerCompat.CreateToastNotifier().Show( toastNotification );
        }
    }
}