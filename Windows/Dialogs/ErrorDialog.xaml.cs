﻿namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows;

    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for ErrorWindow.xaml
    /// </summary>
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "RedundantExtendsListEntry" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBePrivate.Global" ) ]
    [ SuppressMessage( "ReSharper", "ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract" ) ]
    public partial class ErrorDialog : Window
    {
        /// <summary>
        /// The locked object
        /// </summary>
        private object _path;

        /// <summary>
        /// The busy
        /// </summary>
        private bool _busy;

        /// <summary>
        /// The exception
        /// </summary>
        private protected Exception _exception;

        /// <summary>
        /// The title
        /// </summary>
        private protected string _titleText;

        /// <summary>
        /// The message
        /// </summary>
        private protected string _errorMessage;

        /// <summary>
        /// The status update
        /// </summary>
        private protected Action _statusUpdate;

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public Exception Exception
        {
            get
            {
                return _exception;
            }
            private protected set
            {
                _exception = value;
            }
        }

        /// <summary>
        /// Gets the title text.
        /// </summary>
        /// <value>
        /// The title text.
        /// </value>
        public string TitleText
        {
            get
            {
                return _titleText;
            }
            private protected set
            {
                _titleText = value;
            }
        }

        /// <summary>
        /// Gets the message text.
        /// </summary>
        /// <value>
        /// The message text.
        /// </value>
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            private protected set
            {
                _errorMessage = value;
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Windows.Dialogs.ErrorDialog" /> class.
        /// </summary>
        public ErrorDialog( )
        {
            InitializeComponent( );
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Windows.Dialogs.ErrorDialog" />
        /// class.
        /// </summary>
        /// <param name="exception"> The exception. </param>
        public ErrorDialog( Exception exception )
            : this( )
        {
            _exception = exception;
            _errorMessage = exception.ToLogString( Exception?.Message );
            _titleText = "There has been an error!";
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Windows.Dialogs.ErrorDialog" /> class.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="title">The title.</param>
        public ErrorDialog( Exception exception, string title )
            : this( )
        {
            _exception = exception;
            _errorMessage = exception.ToLogString( Exception?.Message );
            _titleText = title;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Windows.Dialogs.ErrorDialog" />
        /// class.
        /// </summary>
        /// <param name="errorMessage"> The message. </param>
        public ErrorDialog( string errorMessage )
            : this( )
        {
            _exception = new Exception( errorMessage );
            _errorMessage = _exception.ToLogString( errorMessage );
            _titleText = "There has been an error!";
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:Badger.Windows.Dialogs.ErrorDialog" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="message">The message.</param>
        public ErrorDialog( string title, string message )
            : this( )
        {
            _exception = new Exception( message );
            _errorMessage = _exception.ToLogString( message );
            _titleText = title;
        }

        /// <summary>
        /// Initializes the callbacks.
        /// </summary>
        private void RegisterCallbacks( )
        {
            try
            {
                //CloseButton.Click += OnCloseButtonClick;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Initializes the delegates.
        /// </summary>
        private void InitializeDelegates( )
        {
            try
            {
                _statusUpdate += UpdateStatus;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Initializes the labels.
        /// </summary>
        private void InitializeLabels( )
        {
            try
            {
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Initializes the text box.
        /// </summary>
        private void InitializeTextBox( )
        {
            try
            {
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Initializes the timer.
        /// </summary>
        private void InitializeTimer( )
        {
            try
            {
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Invokes if needed.
        /// </summary>
        /// <param name="action">The action.</param>
        public void InvokeIf( Action action )
        {
            try
            {
                ThrowIf.Null( action, nameof( action ) );
                if( true )
                {
                    //BeginInvoke( action );
                }
                else
                {
                    action.Invoke( );
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Begins the initialize.
        /// </summary>
        private void StartInit( )
        {
            try
            {
                if( _path == null )
                {
                    _path = new object( );
                    lock( _path )
                    {
                        _busy = true;
                    }
                }
                else
                {
                    lock( _path )
                    {
                        _busy = true;
                    }
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Ends the initialize.
        /// </summary>
        private protected void StopInit( )
        {
            try
            {
                if( _path == null )
                {
                    _path = new object( );
                    lock( _path )
                    {
                        _busy = false;
                    }
                }
                else
                {
                    lock( _path )
                    {
                        _busy = false;
                    }
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Sets the text.
        /// </summary>
        public void SetText( )
        {
            try
            {
                var _logString = _exception.ToLogString( "" );

                //TextBox.Text = _logString;
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Updates the status.
        /// </summary>
        private void UpdateStatus( )
        {
            try
            {
                var _now = DateTime.Now;
                var _date = _now.ToShortDateString( );
                var _status = _now.ToLongTimeString( );

                //StatusLabel.Text = $"{_date} - {_status}";
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary> Called when [load]. </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e">
        /// The
        /// <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        public void OnLoad( object sender, EventArgs e )
        {
            try
            {
                InitializeLabels( );
                InitializeTextBox( );
                InitializeTimer( );
                if( !string.IsNullOrEmpty( _titleText )
                   && !string.IsNullOrEmpty( _errorMessage ) )
                {
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary> Called when [close button click]. </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e">
        /// The
        /// <see cref="EventArgs"/>
        /// instance containing the event data.
        /// </param>
        public void OnCloseButtonClick( object sender, EventArgs e )
        {
            try
            {
                Close( );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Called when [timer tick].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/>
        /// instance containing the event data.</param>
        private void OnTimerTick( object sender, EventArgs e )
        {
            try
            {
                InvokeIf( _statusUpdate );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
            }
        }
        
        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex"> The ex. </param>
        private void Fail( Exception ex )
        {
            Console.WriteLine( ex.Message );
        }
    }
}
