// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace ExecutionInterface.Services
{
    using System;
    using System.Windows.Controls;
    using System.Windows.Navigation;
    using Contracts.Services;
    using Contracts.Views;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ExecutionInterface.Contracts.Services.INavigationService" />
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// The service provider
        /// </summary>
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// The frame
        /// </summary>
        private Frame _frame;

        /// <summary>
        /// The last parameter used
        /// </summary>
        private object _lastParameterUsed;

        /// <summary>
        /// Occurs when [navigated].
        /// </summary>
        public event EventHandler<Type> Navigated;

        /// <summary>
        /// Gets a value indicating whether this instance can go back.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can go back; otherwise, <c>false</c>.
        /// </value>
        public bool CanGoBack
        {
            get
            {
                return _frame.CanGoBack;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationService" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public NavigationService( IServiceProvider serviceProvider )
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Initializes the specified shell frame.
        /// </summary>
        /// <param name="shellFrame">The shell frame.</param>
        public void Initialize( Frame shellFrame )
        {
            if( _frame == null )
            {
                _frame = shellFrame;
                _frame.Navigated += OnNavigated;
            }
        }

        /// <summary>
        /// Unsubscribes the navigation.
        /// </summary>
        public void UnsubscribeNavigation()
        {
            _frame.Navigated -= OnNavigated;
            _frame = null;
        }

        /// <summary>
        /// Goes the back.
        /// </summary>
        public void GoBack()
        {
            if( _frame.CanGoBack )
            {
                var pageBeforeNavigation = _frame.Content;
                _frame.GoBack();

                if( pageBeforeNavigation is INavigationAware navigationAware )
                {
                    navigationAware.OnNavigatedFrom();
                }
            }
        }

        /// <summary>
        /// Navigates to.
        /// </summary>
        /// <param name="pageType">Type of the page.</param>
        /// <param name="parameter">The parameter.</param>
        /// <param name="clearNavigation">if set to <c>true</c> [clear navigation].</param>
        /// <returns></returns>
        public bool NavigateTo( Type pageType, object parameter = null,
            bool clearNavigation = false )
        {
            if( _frame.Content?.GetType() != pageType
                || parameter?.Equals( _lastParameterUsed ) == false )
            {
                _frame.Tag = clearNavigation;
                var page = _serviceProvider.GetService( pageType ) as Page;

                var navigated = _frame.Navigate( page, parameter );

                if( navigated )
                {
                    _lastParameterUsed = parameter;

                    if( _frame.Content is INavigationAware navigationAware )
                    {
                        navigationAware.OnNavigatedFrom();
                    }
                }

                return navigated;
            }

            return false;
        }

        /// <summary>
        /// Cleans the navigation.
        /// </summary>
        public void CleanNavigation()
        {
            _frame.CleanNavigation();
        }

        /// <summary>
        /// Called when [navigated].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NavigationEventArgs" /> instance containing the event data.</param>
        private void OnNavigated( object sender, NavigationEventArgs e )
        {
            if( sender is Frame frame )
            {
                var clearNavigation = (bool)frame.Tag;

                if( clearNavigation )
                {
                    frame.CleanNavigation();
                }

                if( frame.Content is INavigationAware navigationAware )
                {
                    navigationAware.OnNavigatedTo( e.ExtraData );
                }

                Navigated?.Invoke( sender, frame.Content.GetType() );
            }
        }
    }
}