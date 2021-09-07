// <copyright file = "ShellDialogWindow.xaml.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace ExecutionInterface.Views
{
    using System.Windows;
    using System.Windows.Controls;
    using MahApps.Metro.Controls;
    using Contracts.Views;

    public partial class ShellDialogWindow : MetroWindow, IShellDialogWindow
    {
        public ShellDialogWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public Frame GetDialogFrame()
        {
            return dialogFrame;
        }

        private void OnCloseClick( object sender, RoutedEventArgs e )
        {
            DialogResult = true;
            Close();
        }
    }
}