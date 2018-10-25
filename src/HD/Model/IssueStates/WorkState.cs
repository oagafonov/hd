using HD.Exceptions;

namespace HD.Model.IssueStates
{
    public class WorkState : IssueState
    {
        public WorkState(Issue issue) : base(issue)
        {
        }

        public override void Close()
        {
            throw new InvalidStateOperationException("Закрыть сразу из работы Вы издеваетесь?");
        }

        public override void Done()
        {
            if (string.IsNullOrEmpty(Issue.PerformerMessage))
            {
                throw new InvalidStateOperationException("АллЁ введи текст пользователь, е-мое!");
            }

            Issue.SetState(Issue.DoneState);
        }

        public override void Reject()
        {
            Issue.SetState(Issue.RejectState);
        }

        public override void Work()
        {
            throw new InvalidStateOperationException("итак в работе!");
        }
    }
}
