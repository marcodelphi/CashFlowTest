using MediatR;

namespace CashFlowTest.Command.Abstractions
{
    public abstract class Command : Command<Unit>, IRequest
    {
    }

    public abstract class Command<TResult> : IRequest<TResult>
    {
    }

    public abstract class CommandWithId : Command
    {
        public Guid Id { get; }

        public CommandWithId(Guid id)
        {
            Id = id;
        }
    }
}