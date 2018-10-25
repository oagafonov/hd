namespace HD.Model.IssueStates
{
    public abstract class IssueState : IIssueState
    {
        public Issue Issue { get; }

        public IssueState(Issue issue)
        {
            Issue = issue;
        }

        public abstract void Close();
        public abstract void Reject();
        public abstract void Work();
        public abstract void Done();
    }
}
