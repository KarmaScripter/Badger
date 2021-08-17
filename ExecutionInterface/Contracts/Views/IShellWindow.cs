namespace ExecutionInterface.Contracts.Views
{
    using System.Windows.Controls;

    public interface IShellWindow
    {
        Frame GetNavigationFrame();

        void ShowWindow();

        void CloseWindow();
    }
}