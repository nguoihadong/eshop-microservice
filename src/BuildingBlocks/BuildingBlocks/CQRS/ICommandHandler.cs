using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit> where TCommand : ICommand<Unit>
	{

	}

	public interface ICommandHandler<in TCommand, TRespond> : IRequestHandler<TCommand, TRespond> 
        where TCommand : ICommand<TRespond> 
        where TRespond : notnull
	{

    }
}
