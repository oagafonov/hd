using HD.Exceptions;
using HD.Operations;

namespace HD.IssueStates
{
    public class CloseState : IssueState
    {
        public CloseState(Issue issue) : base(issue)
        {
        }

        protected override void ProcessWork()
        {
            Issue.SetState(Issue.WorkState);
        }

        public override IOperationAvailablity OperationAvailablity { get; } = new CloseIssueOperationAvailability();

        public override string ToString()
        {
            return "Closed";
        }
    }
}
