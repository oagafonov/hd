using HD.Exceptions;

namespace HD.Model.IssueStates
{
    public class NewState : IssueState
    {
        public NewState(Issue issue) : base(issue)
        {
        }

        public override void Close()
        {
            throw new InvalidStateOperationException("С чего это сразу закрывать то?!");
        }

        public override void Reject()
        {
            Issue.SetState(Issue.RejectState);
        }

        public override void Work()
        {
            Issue.SetState(Issue.WorkState);
        }

        public override void Done()
        {
            throw new InvalidStateOperationException("ЭЭ ну ты че, куда давайка в работу сначала?!");
        }

        public override string ToString()
        {
            return "New";
        }
    }
}
