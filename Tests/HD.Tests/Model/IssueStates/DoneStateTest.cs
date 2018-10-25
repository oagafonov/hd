using HD.Exceptions;
using HD.Model;
using HD.Model.IssueStates;
using NUnit.Framework;

namespace HD.Tests.Model.IssueStates
{
    public class DoneStateTest : IssueStateTest
    {
        [Test]
        public void CloseTest_Success()
        {
            Issue.Close();

            Assert.AreEqual(Issue.State.GetType(), typeof(CloseState));
        }

        [Test]
        public void RejectTest_ExceptionThrown()
        {
            var ex = Assert.Throws<InvalidStateOperationException>(Issue.Reject);
            Assert.AreEqual(Issue.State.GetType(), typeof(DoneState));
            Assert.That(ex.Message, Is.EqualTo("мы отработали а вы сливаете, ага ща!"));

        }

        [Test]
        public void WorkTest_ExceptionThrown()
        {
            var ex = Assert.Throws<InvalidStateOperationException>(Issue.Work);
            Assert.AreEqual(Issue.State.GetType(), typeof(DoneState));
            Assert.That(ex.Message, Is.EqualTo("мы отработали а вы обратно нас в работу?!"));
        }

        [Test]
        public void DoneTest_ExceptionThrown()
        {
            //Issue.Done();
            var ex = Assert.Throws<InvalidStateOperationException>(Issue.Done);
            Assert.AreEqual(Issue.State.GetType(), typeof(DoneState));
            Assert.That(ex.Message, Is.EqualTo("ЭЭ ну ты че?!"));
        }


        protected override IIssueState CreateCurrentState()
        {
            return new DoneState(Issue);
        }
    }
}
