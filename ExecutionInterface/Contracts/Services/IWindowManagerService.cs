namespace ExecutionInterface.Contracts.Services
{
    using System;
    using System.Windows;

    public interface IWindowManagerService
    {
        Window MainWindow { get; }

        void OpenInNewWindow(Type pageType, object parameter = null);

        bool? OpenInDialog(Type pageType, object parameter = null);

        Window GetWindow(Type pageType);
    }
}
