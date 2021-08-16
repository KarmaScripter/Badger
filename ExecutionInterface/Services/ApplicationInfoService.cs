namespace ExecutionInterface.Services
{
    using System;
    using System.Diagnostics;
    using System.Reflection;

    using ExecutionInterface.Contracts.Services;

    public class ApplicationInfoService : IApplicationInfoService
    {
        public ApplicationInfoService()
        {
        }

        public Version GetVersion()
        {
            // Set the app version in ExecutionInterface > Properties > Package > PackageVersion
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            var version = FileVersionInfo.GetVersionInfo(assemblyLocation).FileVersion;
            return new Version(version);
        }
    }
}
