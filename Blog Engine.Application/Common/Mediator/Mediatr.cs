namespace BlogEngine.Application.Common.Mediator;

public class Mediator : IMediator
{
    private readonly IServiceProvider _provider;

    public Mediator(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
    {
        var requestType = request.GetType();
        var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));
        var handler = _provider.GetService(handlerType);

        if (handler is null)
            throw new InvalidOperationException($"Handler for {requestType.Name} not registered.");

        var method = handlerType.GetMethod("Handle");
        if (method == null)
            throw new InvalidOperationException($"No Handle method on {handlerType.Name}.");

        var task = (Task<TResponse>)method.Invoke(handler, new object[] { request, cancellationToken })!;
        return await task;
    }
}