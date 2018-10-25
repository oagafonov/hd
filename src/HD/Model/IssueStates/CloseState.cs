using HD.Exceptions;

namespace HD.Model.IssueStates
{
    public class CloseState : IssueState
    {
        public CloseState(Issue issue) : base(issue)
        {
        }

        public override void Close()
        {
            throw new InvalidStateOperationException("итак зарыта, мужик не тупи!");
        }

        public override void Reject()
        {
            throw new InvalidStateOperationException("всмысле отказ?!");

        }

        public override void Work()
        {
            Issue.SetState(Issue.WorkState);
        }

        public override void Done()
        {
            throw new InvalidStateOperationException("уже закрыта, стопПэ!");
        }

    }
}
