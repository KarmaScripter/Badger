namespace ExecutionInterface.Core.Contracts.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ExecutionInterface.Core.Models;

    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetGridDataAsync();

        Task<IEnumerable<SampleOrder>> GetContentGridDataAsync();

        Task<IEnumerable<SampleOrder>> GetListDetailsDataAsync();
    }
}
