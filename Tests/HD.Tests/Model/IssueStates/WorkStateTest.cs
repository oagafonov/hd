using HD.Exceptions;
using HD.IssueStates;
using NUnit.Framework;

namespace HD.Tests.Model.IssueStates
{
    public class WorkStateTest : IssueStateTest
    {
        [Test]
        public void CloseTest_ExceptionThrown()
        {
            var ex = Assert.Throws<InvalidStateOperationException>(Issue.Close);
            Assert.AreEqual(Issue.State.GetType(), typeof(WorkState));
            Assert.That(ex.Message, Is.EqualTo("Закрыть сразу из работы Вы издеваетесь?"));
        }

        [Test]
        public void RejectTest_Success()
        {
            Issue.Reject();
            Assert.AreEqual(Issue.State.GetType(), typeof(RejectState));
        }

        [Test]
        public void WorkTest_ExceptionThrown()
        {
            var ex = Assert.Throws<InvalidStateOperationException>(Issue.Work);
            Assert.AreEqual(Issue.State.GetType(), typeof(WorkState));
            Assert.That(ex.Message, Is.EqualTo("итак в работе!"));
        }

        [Test]
        public void DoneTest_ExceptionThrown()
        {
            var ex = Assert.Throws<InvalidStateOperationException>(Issue.Done);
            Assert.AreEqual(Issue.State.GetType(), typeof(WorkState));
            Assert.That(ex.Message, Is.EqualTo("АллЁ введи текст пользователь, е-мое!"));
        }

        [Test]
        public void DoneTest_Success()
        {
            Issue.PerformerMessage = "123";
            Issue.Done();
            Assert.AreEqual(Issue.State.GetType(), typeof(DoneState));
            
        }

        protected override IIssueState CreateCurrentState()
        {
            return new WorkState(Issue);
        }
    }
}
