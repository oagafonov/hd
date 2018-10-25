namespace HD.Commands
{
    public abstract class Command : ICommand {
        public static string Work = "ISSUE_WORK";
        public static string Close = "ISSUE_CLOSE";
        public static string Done = "ISSUE_DONE";
        public static string Reject = "ISSUE_REJECT";

        public abstract string Id { get; }
        public abstract string Text { get; }

        public abstract void Execute(object o);

    }
    public abstract class Command<T> : Command, ICommand<T>
    {


        //public abstract string Id { get; }
        //public abstract string Text { get; }

        public abstract void Execute(T o);

        public override void Execute(object o)
        {
            Execute((T)o);
        }
    }
}
