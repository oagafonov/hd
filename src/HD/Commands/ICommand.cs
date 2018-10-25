namespace HD.Commands
{
    public interface ICommand
    {
        string Id { get; }
        string Text { get; }
        void Execute(object o);
    }

    public interface ICommand<T> : ICommand
    {
        void Execute(T o);
    }

}
