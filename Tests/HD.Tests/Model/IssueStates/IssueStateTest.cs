using HD.IssueStates;
using NUnit.Framework;

namespace HD.Tests.Model.IssueStates
{
    public abstract class IssueStateTest
    {
        protected Issue Issue { get; private set; }

        [SetUp]
        public void SetUp()
        {
            Initialize();
        }

        private void Initialize()
        {
            Issue = new Issue();
            Issue.SetState(CreateCurrentState());
        }

        protected abstract IIssueState CreateCurrentState();

    }
}
