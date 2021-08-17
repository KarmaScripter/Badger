// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace ExecutionInterface.Services
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using Contracts.Services;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ExecutionInterface.Contracts.Services.IApplicationInfoService" />
    public class ApplicationInfoService : IApplicationInfoService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationInfoService"/> class.
        /// </summary>
        public ApplicationInfoService()
        {
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <returns></returns>
        public Version GetVersion()
        {
            // Set the app version in ExecutionInterface > Properties > Package > PackageVersion
            var _assemblyLocation = Assembly.GetExecutingAssembly().Location;
            var _version = FileVersionInfo.GetVersionInfo( _assemblyLocation ).FileVersion;
            return new Version( _version );
        }
    }
}