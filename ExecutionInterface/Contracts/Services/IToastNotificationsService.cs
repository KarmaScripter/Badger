namespace ExecutionInterface.Contracts.Services
{
    using Windows.UI.Notifications;

    public interface IToastNotificationsService
    {
        public void ShowToastNotification( ToastNotification toastNotification );

        public void ShowToastNotificationSample();
    }
}