using HD.Exceptions;

namespace HD.Model.IssueStates
{
    public class DoneState : IssueState
    {
        public DoneState(Issue issue) : base(issue)
        {
        }

        public override void Close()
        {
            Issue.SetState(Issue.CloseState);
        }

        public override void Reject()
        {
            throw new InvalidStateOperationException("мы отработали а вы сливаете, ага ща!");
        }

        public override void Work()
        {
            throw new InvalidStateOperationException("мы отработали а вы обратно нас в работу?!");
        }

        public override void Done()
        {
            throw new InvalidStateOperationException("ЭЭ ну ты че?!");
        }
    }
}
