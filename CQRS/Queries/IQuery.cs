using MediatR;

namespace CQRS
{
    public class IQuery<T>: IRequest<T>
    {
    }
}
