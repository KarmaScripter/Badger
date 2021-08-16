namespace ExecutionInterface.Services
{
    using Microsoft.Toolkit.Uwp.Notifications;

    using ExecutionInterface.Contracts.Services;

    using Windows.UI.Notifications;

    public partial class ToastNotificationsService : IToastNotificationsService
    {
        public ToastNotificationsService()
        {
        }

        public void ShowToastNotification(ToastNotification toastNotification)
        {
            ToastNotificationManagerCompat.CreateToastNotifier().Show(toastNotification);
        }
    }
}
