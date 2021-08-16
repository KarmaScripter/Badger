namespace ExecutionInterface.Contracts.Services
{
    using System;

    using ExecutionInterface.Models;

    public interface IThemeSelectorService
    {
        void InitializeTheme();

        void SetTheme(AppTheme theme);

        AppTheme GetCurrentTheme();
    }
}
