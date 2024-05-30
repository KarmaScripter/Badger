﻿// ******************************************************************************************
//     Assembly:                Badger
//     Author:                  Terry D. Eppler
//     Created:                 1-27-2024
// 
//     Last Modified By:        Terry D. Eppler
//     Last Modified On:        1-27-2024
// ******************************************************************************************
// <copyright file="ExcelMeasure.cs" company="Terry D. Eppler">
//    Badger is a Federal Budget, Finance, and Accounting application
//    for analysts with the US Environmental Protection Agency (US EPA).
//    Copyright ©  2024  Terry Eppler
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
//    Contact at:  terryeppler@gmail.com or eppler.terry@epa.gov
// </copyright>
// <summary>
//   ExcelMeasure.cs
// </summary>
// ******************************************************************************************

namespace Badger
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using OfficeOpenXml.Interfaces.Drawing.Text;
    using SkiaSharp;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="OfficeOpenXml.Interfaces.Drawing.Text.ITextMeasurer" />
    [ SuppressMessage( "ReSharper", "CommentTypo" ) ]
    [ SuppressMessage( "ReSharper", "ConvertSwitchStatementToSwitchExpression" ) ]
    [ SuppressMessage( "ReSharper", "UnusedType.Global" ) ]
    [ SuppressMessage( "ReSharper", "ClassCanBeSealed.Global" ) ]
    [ SuppressMessage( "ReSharper", "MemberCanBeInternal" ) ]
    public class TextSize : ITextMeasurer
    {
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="TextSize"/> class.
        /// </summary>
        public TextSize( )
        {
        }

        /// <summary>
        /// Converts to skfontstyle.
        /// </summary>
        /// <param name="style">The style.</param>
        /// <returns></returns>
        private SKFontStyle ToSkFontStyle( MeasurementFontStyles style )
        {
            try
            {
                switch( style )
                {
                    case MeasurementFontStyles.Regular:
                    {
                        return SKFontStyle.Normal;
                    }
                    case MeasurementFontStyles.Bold:
                    {
                        return SKFontStyle.Bold;
                    }
                    case MeasurementFontStyles.Italic:
                    {
                        return SKFontStyle.Italic;
                    }
                    case MeasurementFontStyles.Bold | MeasurementFontStyles.Italic:
                    {
                        return SKFontStyle.BoldItalic;
                    }
                    default:
                    {
                        return SKFontStyle.Normal;
                    }
                }
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( SKFontStyle );
            }
        }

        /// <summary>
        /// Measures the text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <returns></returns>
        public TextMeasurement MeasureText( string text, MeasurementFont font )
        {
            try
            {
                ThrowIf.Null( text, nameof( text ) );
                var _fontStyle = ToSkFontStyle( font.Style );
                var _typeface = SKTypeface.FromFamilyName( font.FontFamily, _fontStyle );
                using var _paint = new SKPaint( );
                _paint.TextSize = font.Size;
                _paint.Typeface = _typeface;
                var _rect = SKRect.Empty;
                _paint.MeasureText( text.AsSpan( ), ref _rect );
                var _width = ( _rect.Width / 0.7282505F ) + ( 0.444444444F * font.Size );
                var _height = _rect.Height * ( 96F / 72F );
                var _measure = new TextMeasurement( _width, _height );
                return _measure.IsEmpty != true
                    ? _measure
                    : default( TextMeasurement );
            }
            catch( Exception _ex )
            {
                Fail( _ex );
                return default( TextMeasurement );
            }
        }

        /// <summary>
        /// Valids for environment.
        /// </summary>
        /// <returns></returns>
        public bool ValidForEnvironment( )
        {
            return true;
        }

        /// <summary>
        /// Fails the specified ex.
        /// </summary>
        /// <param name="ex">The ex.</param>
        private void Fail( Exception ex )
        {
            var _error = new ErrorWindow( ex );
            _error?.SetText( );
            _error?.ShowDialog( );
        }
    }
}