// <copyright file=" <File Name> .cs" company="Terry D. Eppler">
// Copyright (c) Terry Eppler. All rights reserved.
// </copyright>

namespace ExecutionInterface.Core.Services
{
    using System.IO;
    using System.Text;
    using Newtonsoft.Json;
    using Contracts.Services;

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ExecutionInterface.Core.Contracts.Services.IFileService" />
    public class FileService : IFileService
    {
        /// <summary>
        /// Reads the specified folder path.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="folderPath">The folder path.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public T Read<T>( string folderPath, string fileName )
        {
            var path = Path.Combine( folderPath, fileName );

            if( File.Exists( path ) )
            {
                var json = File.ReadAllText( path );
                return JsonConvert.DeserializeObject<T>( json );
            }

            return default( T );
        }

        /// <summary>
        /// Saves the specified folder path.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="folderPath">The folder path.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="content">The content.</param>
        public void Save<T>( string folderPath, string fileName, T content )
        {
            if( !Directory.Exists( folderPath ) )
            {
                Directory.CreateDirectory( folderPath );
            }

            var fileContent = JsonConvert.SerializeObject( content );
            File.WriteAllText( Path.Combine( folderPath, fileName ), fileContent, Encoding.UTF8 );
        }

        /// <summary>
        /// Deletes the specified folder path.
        /// </summary>
        /// <param name="folderPath">The folder path.</param>
        /// <param name="fileName">Name of the file.</param>
        public void Delete( string folderPath, string fileName )
        {
            if( fileName != null
                && File.Exists( Path.Combine( folderPath, fileName ) ) )
            {
                File.Delete( Path.Combine( folderPath, fileName ) );
            }
        }
    }
}