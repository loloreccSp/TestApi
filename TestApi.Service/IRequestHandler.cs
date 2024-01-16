
namespace TestApiMovie.Service
{
    public interface IRequestHandler<in TRequest, TResponce>
    {
        Task<TResponce> Handle(TRequest request, CancellationToken cancellationToken = default);
    }
    public interface IRequestHandler<TResponce>
    {
        Task<TResponce> Handle(CancellationToken cancellationToken = default);
    }
}
