using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HD.Exceptions;
using HD.Model;

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
                Console.WriteLine("Enter issue operations: 1 - In process, 2 - Reject, 3 - Done, 4 - Close, 0 - exit");
                var command = Console.ReadKey();
                Console.WriteLine();
                try
                {
                    switch (command.Key)
                    {
                        case ConsoleKey.D0:
                            return;
                        case ConsoleKey.D1:
                            issue.Work();
                            break;
                        case ConsoleKey.D2:
                            issue.Work();
                            break;
                        case ConsoleKey.D3:
                            issue.Done();
                            break;
                        case ConsoleKey.D4:
                            issue.Close();
                            break;
                    }
                    PrintIssue(issue);
                }
                catch (InvalidStateOperationException e)
                {
                    Console.WriteLine($"Error when process operation: {e.Message}");
                }
            }
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
