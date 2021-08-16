namespace ExecutionInterface.Views
{
    using System.Windows;
    using System.Windows.Controls;

    using MahApps.Metro.Controls;

    using ExecutionInterface.Contracts.Views;

    public partial class ShellDialogWindow : MetroWindow, IShellDialogWindow
    {
        public ShellDialogWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public Frame GetDialogFrame()
            => dialogFrame;

        private void OnCloseClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
