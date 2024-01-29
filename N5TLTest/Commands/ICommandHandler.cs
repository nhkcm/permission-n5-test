namespace N5TLTest.Commands
{
    public interface ICommandHandler<T>
    {
        Task Handle(T command);
    }
}
