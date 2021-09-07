namespace ExecutionInterface.Contracts.Services
{
    using Models;

    public interface IThemeSelectorService
    {
        void InitializeTheme();

        void SetTheme( AppTheme theme );

        AppTheme GetCurrentTheme();
    }
}