using HD.Exceptions;
using HD.Operations;

namespace HD.IssueStates
{
    public abstract class IssueState : IIssueState
    {
        public Issue Issue { get; }

        public IssueState(Issue issue)
        {
            Issue = issue;
        }

        public void Close()
        {
            if (OperationAvailablity.CanClose)
                ProcessReject();
            else
                throw new InvalidStateOperationException("Нельзя закрыть заявку");
        }

        public void Reject()
        {
            if (OperationAvailablity.CanReject)
                ProcessReject();
            else
                throw new InvalidStateOperationException("Нельзя отклонить заявку");
        }

        public void Work()
        {
            if (OperationAvailablity.CanWork)
                ProcessWork();
            else
                throw new InvalidStateOperationException("Нельзя перевести заявку в работу");
        }

        public void Done()
        {
            if (OperationAvailablity.CanDone)
                ProcessDone();
            else
                throw new InvalidStateOperationException("Нельзя выполнить заявку");
        }

        public virtual IOperationAvailablity OperationAvailablity { get; } = new AllDenyOperationAvailability();

        protected virtual void ProcessClose()
        {
        }

        protected virtual void ProcessReject()
        {
        }

        protected virtual void ProcessWork()
        {
        }

        protected virtual void ProcessDone()
        {
        }
    }
}
