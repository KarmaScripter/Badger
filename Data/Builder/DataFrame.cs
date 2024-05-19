﻿// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 03-24-2023
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        05-31-2023
// ******************************************************************************************
// <copyright file="ModelBase.cs" company="Terry D. Eppler">
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
//   ModelBase.cs
// </summary>
// ****************************************************************************************

namespace Badger
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc/>
    /// <summary> </summary>
    /// <seealso cref="T:Badger.DataAccess"/>
    [ SuppressMessage( "ReSharper", "ArrangeDefaultValueWhenTypeNotEvident" ) ]
    [ SuppressMessage( "ReSharper", "InconsistentNaming" ) ]
    [ SuppressMessage( "ReSharper", "ArrangeAccessorOwnerBody" ) ]
    public abstract class DataFrame : DataAccess
    {
        /// <summary>
        /// Gets the ordinals.
        /// </summary>
        /// <returns></returns>
        private protected IEnumerable<int> GetOrdinals( )
        {
            try
            {
                if( _dataTable != null )
                {
                    _dataTable = GetDataTable( );
                }

                var _columns = _dataTable?.Columns;
                var _values = new List<int>( );
                if( _columns?.Count > 0 )
                {
                    foreach( DataColumn _column in _columns )
                    {
                        if( _column != null )
                        {
                            _values?.Add( _column.Ordinal );
                        }
                    }
                }

                return _values?.Any( ) == true
                    ? _values
                    : default( IEnumerable<int> );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IEnumerable<int> );
            }
        }

        /// <summary>
        /// Gets the column schema.
        /// </summary>
        /// <returns>
        /// </returns>
        private protected IDictionary<string, Type> GetColumnSchema( )
        {
            try
            {
                if( _dataTable != null )
                {
                    _dataTable = GetDataTable( );
                }

                var _columns = _dataTable?.Columns;
                var _schema = new Dictionary<string, Type>( );
                if( _columns?.Count > 0 )
                {
                    foreach( DataColumn _col in _columns )
                    {
                        _schema.Add( _col.ColumnName, _col.DataType );
                    }
                }

                return _schema?.Any( ) == true
                    ? _schema
                    : default( IDictionary<string, Type> );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IDictionary<string, Type> );
            }
        }

        /// <summary>
        /// Gets the data columns.
        /// </summary>
        /// <returns>
        /// </returns>
        private protected IList<DataColumn> GetDataColumns( )
        {
            try
            {
                if( _dataTable != null )
                {
                    _dataTable = GetDataTable( );
                }

                var _list = new List<DataColumn>( );
                var _data = _dataTable?.Columns;
                if( _data?.Count > 0 )
                {
                    foreach( DataColumn _column in _data )
                    {
                        if( _column != null )
                        {
                            _list.Add( _column );
                        }
                    }
                }

                return _list?.Any( ) == true
                    ? _list
                    : default( IList<DataColumn> );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IList<DataColumn> );
            }
        }

        /// <summary>
        /// Gets the column names.
        /// </summary>
        /// <returns>
        /// </returns>
        private protected IList<string> GetColumnNames( )
        {
            try
            {
                if( _dataTable != null )
                {
                    _dataTable = GetDataTable( );
                }

                var _list = new List<string>( );
                var _data = _dataTable?.Columns;
                if( _data?.Count > 0 )
                {
                    foreach( DataColumn _column in _data )
                    {
                        if( !string.IsNullOrEmpty( _column?.ColumnName ) )
                        {
                            _list.Add( _column.ColumnName );
                        }
                    }

                    return _list?.Any( ) == true
                        ? _list
                        : default( IList<string> );
                }
                else
                {
                    return default( IList<string> );
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( IList<string> );
            }
        }
    }
}