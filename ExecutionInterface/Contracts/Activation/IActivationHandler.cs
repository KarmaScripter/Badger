namespace ExecutionInterface.Contracts.Activation
{
    using System.Threading.Tasks;

    public interface IActivationHandler
    {
        bool CanHandle();

        Task HandleAsync();
    }
}
