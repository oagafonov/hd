using HD.Exceptions;
using HD.Operations;

namespace HD.IssueStates
{
    public class RejectState : IssueState
    {
        public RejectState(Issue issue) : base(issue)
        {
        }
        
        protected override void ProcessWork()
        {
            Issue.SetState(Issue.WorkState);
        }

        public override IOperationAvailablity OperationAvailablity { get; } = new RejectIssueOperationAvailability();

        public override string ToString()
        {
            return "Rejected";
        }
    }
}
