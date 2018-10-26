using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HD.Exceptions;

namespace HD.Client
{
    class Program
    {
        private static readonly List<Issue> _issues = new List<Issue>();

        static void Main(string[] args)
        {
            Console.WriteLine("");
            while (true)
            {
                Console.WriteLine("Enter command: 1 - list issues, 2 - create new issus, 3 - select issue, 0 - exit");
                var command = Console.ReadKey();
                Console.WriteLine();
                switch (command.Key)
                {
                    case ConsoleKey.D0:
                        return;
                    case ConsoleKey.D1:
                        PrintList();
                        break;
                    case ConsoleKey.D2:
                        CreateNewIssues();
                        PrintList();
                        break;
                    case ConsoleKey.D3:
                        SelectIssues();
                        break;
                }
            }
        }

        private static void SelectIssues()
        {
            PrintList();
            Console.WriteLine("Enter ID of issues for select");
            var issueId = Console.ReadLine();
            var issue = _issues.FirstOrDefault(i => i.Id.ToString().Equals(issueId));
            if (issue != null)
            {
                Console.WriteLine("You've selected issuse: ");
                PrintIssue(issue);
                ProcessIssue(issue);
            }
            else
                Console.WriteLine("Issue not exists");
        }

        private static void ProcessIssue(Issue issue)
        {
            while (true)
            {
                var operations = BuildOperations(issue);
                var operationText = "Enter issue operations: 0 - exit, ";

                foreach (var operation in operations)
                {
                    operationText += $"{operation.Value.Item1}, ";
                }

                Console.WriteLine(operationText);

                var command = Console.ReadKey();
                Console.WriteLine();

                try
                {
                    if (command.Key == ConsoleKey.D0)
                        return;
                    if (operations.ContainsKey(command.Key))
                    {
                        operations[command.Key].Item2();
                        PrintIssue(issue);
                    }
                }
                catch (InvalidStateOperationException e)
                {
                    Console.WriteLine($"Error when process operation: {e.Message}");
                }
            }
        }

        private static Dictionary<ConsoleKey, Tuple<string, Action>> BuildOperations(Issue issue)
        {
            var operations = new Dictionary<ConsoleKey, Tuple<string, Action>>();

            if (issue.State.OperationAvailablity.CanWork)
                operations.Add(ConsoleKey.D1, new Tuple<string, Action>("1 - In process", issue.Work));
            if (issue.State.OperationAvailablity.CanReject)
                operations.Add(ConsoleKey.D2, new Tuple<string, Action>("2 - Reject", issue.Reject));
            if (issue.State.OperationAvailablity.CanDone)
                operations.Add(ConsoleKey.D3, new Tuple<string, Action>("3 - Done", issue.Done));
            if (issue.State.OperationAvailablity.CanClose)
                operations.Add(ConsoleKey.D4, new Tuple<string, Action>("4 - Close", issue.Close));

            return operations;
        }

        private static void CreateNewIssues()
        {
            _issues.Add(new Issue
            {
                Id = _issues.Count + 1,
                Text = $"Issue {_issues.Count + 1}"
            });
        }

        private static void PrintList()
        {
            Console.WriteLine($"Printing list of issues ({_issues.Count}):");
            foreach (var issue in _issues)
            {
                PrintIssue(issue);
            }
        }

        private static void PrintIssue(Issue issue)
        {
            Console.WriteLine($"{issue.Id}\t{issue.Text}\t{issue.State}");
        }
    }
}
