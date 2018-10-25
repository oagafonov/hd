using HD.Exceptions;

namespace HD.Model.IssueStates
{
    public class RejectState : IssueState
    {
        public RejectState(Issue issue) : base(issue)
        {
        }

        public override void Close()
        {
            throw new InvalidStateOperationException("Типо отмененная заявка!");
        }

        public override void Done()
        {
            throw new InvalidStateOperationException("Типо отмененная заявка!");
        }

        public override void Reject()
        {
            throw new InvalidStateOperationException("Итак отменена!");
        }

        public override void Work()
        {
            Issue.SetState(Issue.WorkState);
        }
    }
}
