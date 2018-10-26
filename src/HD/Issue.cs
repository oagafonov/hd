using HD.Commands;
using HD.IssueStates;

namespace HD
{
    public class Issue
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string PerformerMessage { get; set; }

        public IIssueState State { get; private set; }

        internal WorkState WorkState { get; }
        internal CloseState CloseState { get; }
        internal DoneState DoneState { get; }
        internal RejectState RejectState { get; }
        

        public Issue()
        {
            WorkState = new WorkState(this);
            CloseState = new CloseState(this);
            DoneState = new DoneState(this);
            RejectState = new RejectState(this);

            SetState(new NewState(this));
        }

        public ICommand[] AvailableCommands()
        {
            return null;
        }

        internal void SetState(IIssueState state)
        {
            State = state;
        }

        /// <summary>
        /// Перевести в работу
        /// </summary>
        public void Work()
        {
            State.Work();
        }

        /// <summary>
        /// Закрыть
        /// </summary>
        public void Close() {
            State.Close();
        }

        /// <summary>
        /// Отказать в исполнении
        /// </summary>
        public void Reject() {
            State.Reject();
        }

        /// <summary>
        /// Выполнена
        /// </summary>
        public void Done()
        {
            State.Done();
        }
    }
}
