using HD.Commands;
using HD.Model;
using NUnit.Framework;

namespace HD.Tests.Commands
{
    public class WorkCommandTest
    {
        [Test]
        public void WorkCommandExecuteTest()
        {
            var command = CommandManager.GetCommand(Command.Work);
            var issue = new Issue();
            
            command.Execute(issue);

        }
    }
}
