namespace ExecutionInterface.Services
{
    using System;
    using System.Windows;
    using ControlzEx.Theming;
    using MahApps.Metro.Theming;
    using Contracts.Services;
    using Models;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ExecutionInterface.Contracts.Services.IThemeSelectorService" />
    public class ThemeSelectorService : IThemeSelectorService
    {
        /// <summary>
        /// The hc dark theme
        /// </summary>
        private const string _hcDarkTheme = "pack://application:,,,/Styles/Themes/HC.Dark.Blue.xaml";

        /// <summary>
        /// The hc light theme
        /// </summary>
        private const string _hcLightTheme =
            "pack://application:,,,/Styles/Themes/HC.Light.Blue.xaml";

        /// <summary>
        /// Initializes a new instance of the <see cref="ThemeSelectorService"/> class.
        /// </summary>
        public ThemeSelectorService()
        {
        }

        /// <summary>
        /// Initializes the theme.
        /// </summary>
        public void InitializeTheme()
        {
            // TODO WTS: Mahapps.Metro supports syncronization with high contrast but you have to provide custom high contrast themes
            // We've added basic high contrast dictionaries for Dark and Light themes
            // Please complete these themes following the docs on https://mahapps.com/docs/themes/thememanager#creating-custom-themes
            ThemeManager.Current.AddLibraryTheme( new LibraryTheme( new Uri( ThemeSelectorService._hcDarkTheme ),
                MahAppsLibraryThemeProvider.DefaultInstance ) );

            ThemeManager.Current.AddLibraryTheme( new LibraryTheme(
                new Uri( ThemeSelectorService._hcLightTheme ),
                MahAppsLibraryThemeProvider.DefaultInstance ) );

            var theme = GetCurrentTheme();
            SetTheme( theme );
        }

        /// <summary>
        /// Sets the theme.
        /// </summary>
        /// <param name="theme">The theme.</param>
        public void SetTheme( AppTheme theme )
        {
            if( theme == AppTheme.Default )
            {
                ThemeManager.Current.ThemeSyncMode = ThemeSyncMode.SyncAll;
                ThemeManager.Current.SyncTheme();
            }
            else
            {
                ThemeManager.Current.ThemeSyncMode = ThemeSyncMode.SyncWithHighContrast;
                ThemeManager.Current.SyncTheme();

                ThemeManager.Current.ChangeTheme( Application.Current, $"{theme}.Blue",
                    SystemParameters.HighContrast );
            }

            App.Current.Properties[ "Theme" ] = theme.ToString();
        }

        /// <summary>
        /// Gets the current theme.
        /// </summary>
        /// <returns></returns>
        public AppTheme GetCurrentTheme()
        {
            if( App.Current.Properties.Contains( "Theme" ) )
            {
                var themeName = App.Current.Properties[ "Theme" ].ToString();
                Enum.TryParse( themeName, out AppTheme theme );
                return theme;
            }

            return AppTheme.Default;
        }
    }
}