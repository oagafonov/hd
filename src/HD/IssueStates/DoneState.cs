using HD.Exceptions;
using HD.Operations;

namespace HD.IssueStates
{
    public class DoneState : IssueState
    {
        public DoneState(Issue issue) : base(issue)
        {
        }

        protected override void ProcessClose()
        {
            Issue.SetState(Issue.CloseState);
        }

        public override IOperationAvailablity OperationAvailablity { get; } = new DoneIssueOperationAvailability();

        public override string ToString()
        {
            return "Done";
        }
    }
}
