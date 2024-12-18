using MediatR;

namespace DesignCrowd.DateManager.Contracts.Shared.Cqrs;

public interface IQuery<out TValue> : IRequest<TValue>;