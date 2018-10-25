using HD.Model;

namespace HD.Commands
{
    public class WorkCommand : Command<Issue>
    {
        public override string Id => Work;
        public override string Text => "В работу";

        public override void Execute(Issue o)
        {
            o.Work();
        }
    }
}
