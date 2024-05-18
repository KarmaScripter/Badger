﻿// ******************************************************************************************
//     Assembly:                Budget Execution
//     Author:                  Terry D. Eppler
//     Created:                 06-19-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        06-22-2023
// ******************************************************************************************
// <copyright file="Some.cs" company="Terry D. Eppler">
//    This is a Federal Budget, Finance, and Accounting application for the
//    US Environmental Protection Agency (US EPA).
//    Copyright ©  2023  Terry Eppler
// 
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the “Software”),
//    to deal in the Software without restriction,
//    including without limitation the rights to use,
//    copy, modify, merge, publish, distribute, sublicense,
//    and/or sell copies of the Software,
//    and to permit persons to whom the Software is furnished to do so,
//    subject to the following conditions:
// 
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.
// 
//    THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
//    INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT.
//    IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
//    DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//    ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
//    DEALINGS IN THE SOFTWARE.
// 
//    You can contact me at:   terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   Some.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <inheritdoc/>
    /// <summary> </summary>
    /// <typeparam name="T"> </typeparam>
    /// <seealso cref="T:Badger.IOption`1"/>
    [ SuppressMessage( "ReSharper", "CompareNonConstrainedGenericWithNull" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    public class Some<T> : Option<T>
    {
        /// <summary>
        /// The value
        /// </summary>
        private readonly T _value;

        /// <inheritdoc/>
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value> The value. </value>
        public override T Value
        {
            get
            {
                return _value;
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets a value indicating whether this instance is some.
        /// </summary>
        /// <value>
        /// <c> true </c>
        /// if this instance is some; otherwise,
        /// <c> false </c>
        /// .
        /// </value>
        public override bool IsSome
        {
            get
            {
                return true;
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Gets a value indicating whether this instance is none.
        /// </summary>
        /// <value>
        /// <c> true </c>
        /// if this instance is none; otherwise,
        /// <c> false </c>
        /// .
        /// </value>
        public override bool IsNone
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Some{T}" />
        /// class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentNullException">
        /// value - Some value was null, use Empty instead
        /// </exception>
        public Some( T value )
        {
            if( value == null )
            {
                var _msg = "The value for 'Some' was null...use 'Empty' instead";
                throw new ArgumentNullException( nameof( value ), _msg );
            }

            _value = value;
        }

        /// <inheritdoc/>
        /// <summary>
        /// Maps the specified function.
        /// </summary>
        /// <typeparam name="TResult"> The type of the result. </typeparam>
        /// <param name="func"> The function. </param>
        /// <returns>
        /// Option{TResult}
        /// </returns>
        public override Option<TResult> Map<TResult>( Func<T, TResult> func )
        {
            try
            {
                return new Some<TResult>( func( _value ) );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( Option<TResult> );
            }
        }

        /// <inheritdoc/>
        /// <summary>
        /// Matches the specified some function.
        /// </summary>
        /// <typeparam name="TResult"> The type of the result. </typeparam>
        /// <param name="someFunc"> Some function. </param>
        /// <param name="noneFunc"> The none function. </param>
        /// <returns>
        /// TResult
        /// </returns>
        public override TResult Match<TResult>( Func<T, TResult> someFunc, Func<TResult> noneFunc )
        {
            try
            {
                return someFunc( _value );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( TResult );
            }
        }
    }
}