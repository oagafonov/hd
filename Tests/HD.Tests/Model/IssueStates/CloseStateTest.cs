using HD.Exceptions;
using HD.Model;
using HD.Model.IssueStates;
using NUnit.Framework;

namespace HD.Tests.Model.IssueStates
{
    class CloseStateTest : IssueStateTest
    {
        [Test]
        public void CloseTest_ExceptionThrown()
        {
            var ex = Assert.Throws<InvalidStateOperationException>(Issue.Close);
            Assert.AreEqual(Issue.State.GetType(), typeof(CloseState));
            Assert.That(ex.Message, Is.EqualTo("итак зарыта, мужик не тупи!"));
        }

        [Test]
        public void RejectTest_ExceptionThrown()
        {
            var ex = Assert.Throws<InvalidStateOperationException>(Issue.Reject);
            Assert.AreEqual(Issue.State.GetType(), typeof(CloseState));
            Assert.That(ex.Message, Is.EqualTo("всмысле отказ?!"));

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
            var ex = Assert.Throws<InvalidStateOperationException>(Issue.Done);
            Assert.AreEqual(Issue.State.GetType(), typeof(CloseState));
            Assert.That(ex.Message, Is.EqualTo("уже закрыта, стопПэ!"));
        }


        protected override IIssueState CreateCurrentState()
        {
            return new CloseState(Issue);
        }
    }
}
