// <copyright file="PersistAndRestoreService.cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace ExecutionInterface.Services
{
    using System;
    using System.Collections;
    using System.IO;
    using Microsoft.Extensions.Options;
    using Contracts.Services;
    using Core.Contracts.Services;
    using Models;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ExecutionInterface.Contracts.Services.IPersistAndRestoreService" />
    public class PersistAndRestoreService : IPersistAndRestoreService
    {
        /// <summary>
        /// The file service
        /// </summary>
        private readonly IFileService _fileService;

        /// <summary>
        /// The application configuration
        /// </summary>
        private readonly AppConfig _appConfig;

        /// <summary>
        /// The local application data
        /// </summary>
        private readonly string _localAppData =
            Environment.GetFolderPath( Environment.SpecialFolder.LocalApplicationData );

        /// <summary>
        /// Initializes a new instance of the <see cref="PersistAndRestoreService"/> class.
        /// </summary>
        /// <param name="fileService">The file service.</param>
        /// <param name="appConfig">The application configuration.</param>
        public PersistAndRestoreService( IFileService fileService, IOptions<AppConfig> appConfig )
        {
            _fileService = fileService;
            _appConfig = appConfig.Value;
        }

        /// <summary>
        /// Persists the data.
        /// </summary>
        public void PersistData()
        {
            if( App.Current.Properties != null )
            {
                var _folderPath = Path.Combine( _localAppData, _appConfig.ConfigurationsFolder );
                var _fileName = _appConfig.AppPropertiesFileName;
                _fileService.Save( _folderPath, _fileName, App.Current.Properties );
            }
        }

        /// <summary>
        /// Restores the data.
        /// </summary>
        public void RestoreData()
        {
            var _folderPath = Path.Combine( _localAppData, _appConfig.ConfigurationsFolder );
            var _fileName = _appConfig.AppPropertiesFileName;
            var _properties = _fileService.Read<IDictionary>( _folderPath, _fileName );

            if( _properties != null )
            {
                foreach( DictionaryEntry property in _properties )
                {
                    App.Current.Properties.Add( property.Key, property.Value );
                }
            }
        }
    }
}