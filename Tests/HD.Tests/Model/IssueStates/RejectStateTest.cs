using HD.Exceptions;
using HD.IssueStates;
using NUnit.Framework;

namespace HD.Tests.Model.IssueStates
{
    public class RejectStateTest : IssueStateTest
    {
        [Test]
        public void CloseTest_ExceptionThrown()
        {
            var ex = Assert.Throws<InvalidStateOperationException>(Issue.Close);
            Assert.AreEqual(Issue.State.GetType(), typeof(RejectState));
            Assert.That(ex.Message, Is.EqualTo("Типо отмененная заявка!"));
        }

        [Test]
        public void RejectTest_ExceptionThrown()
        {
            var ex = Assert.Throws<InvalidStateOperationException>(Issue.Reject);
            Assert.AreEqual(Issue.State.GetType(), typeof(RejectState));
            Assert.That(ex.Message, Is.EqualTo("Итак отменена!"));

        }

        [Test]
        public void WorkTest_Success()
        {
            Issue.Work();
            Assert.AreEqual(Issue.State.GetType(), typeof(WorkState));
        }

        [Test]
        public void DoneTest_ExceptionThrown()
        {
            Issue.PerformerMessage = "123";
           
            var ex = Assert.Throws<InvalidStateOperationException>(Issue.Done);
            Assert.AreEqual(Issue.State.GetType(), typeof(RejectState));
            Assert.That(ex.Message, Is.EqualTo("Типо отмененная заявка!"));
        }

        protected override IIssueState CreateCurrentState()
        {
            return new RejectState(Issue);
        }
    }
}
