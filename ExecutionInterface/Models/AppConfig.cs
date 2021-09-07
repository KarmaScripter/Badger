// <copyright file = "AppConfig.cs" company = "Terry D. Eppler">
// Copyright (c) Terry D. Eppler. All rights reserved.
// </copyright>

namespace ExecutionInterface.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// Gets or sets the configurations folder.
        /// </summary>
        /// <value>
        /// The configurations folder.
        /// </value>
        public string ConfigurationsFolder { get; set; }

        /// <summary>
        /// Gets or sets the name of the application properties file.
        /// </summary>
        /// <value>
        /// The name of the application properties file.
        /// </value>
        public string AppPropertiesFileName { get; set; }

        /// <summary>
        /// Gets or sets the privacy statement.
        /// </summary>
        /// <value>
        /// The privacy statement.
        /// </value>
        public string PrivacyStatement { get; set; }
    }
}