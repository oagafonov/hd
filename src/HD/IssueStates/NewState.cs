using HD.Exceptions;
using HD.Operations;

namespace HD.IssueStates
{
    public class NewState : IssueState
    {
        public NewState(Issue issue) : base(issue)
        {
        }

        protected override void ProcessReject()
        {
            Issue.SetState(Issue.RejectState);
        }

        protected override void ProcessWork()
        {
            Issue.SetState(Issue.WorkState);
        }

        public override string ToString()
        {
            return "New";
        }

        public override IOperationAvailablity OperationAvailablity { get; } = new NewIssueOperationAvailability();
    }
}
