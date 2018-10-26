using HD.Exceptions;
using HD.Operations;

namespace HD.IssueStates
{
    public class WorkState : IssueState
    {
        public WorkState(Issue issue) : base(issue)
        {
        }

        protected override void ProcessDone()
        {
            if (string.IsNullOrEmpty(Issue.PerformerMessage))
            {
                throw new InvalidStateOperationException("АллЁ введи текст пользователь, е-мое!");
            }

            Issue.SetState(Issue.DoneState);
        }

        protected override void ProcessReject()
        {
            Issue.SetState(Issue.RejectState);
        }

        public override IOperationAvailablity OperationAvailablity { get; } = new WorkIssueOperationAvailability();

        public override string ToString()
        {
            return "In process";
        }
    }
}
