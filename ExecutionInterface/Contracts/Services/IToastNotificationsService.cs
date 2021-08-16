namespace ExecutionInterface.Contracts.Services
{
    using Windows.UI.Notifications;

    public interface IToastNotificationsService
    {
        public abstract void ShowToastNotification(ToastNotification toastNotification);

        public abstract void ShowToastNotificationSample();
    }
}
