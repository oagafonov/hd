using System;
using System.Collections.Generic;

namespace HD.Commands
{
    public static class CommandManager
    {
        static CommandManager()
        {
            Commands = new Dictionary<string, Type>();
            //CommandsName = new Dictionary<string, string>();
            Register<WorkCommand>(Command.Work, Command.Work);
        }

        public static Dictionary<string, Type> Commands { get; }
        //public static Dictionary<string, string> CommandsName { get; }

        static void Register<T>(string id, string name)
            where T : ICommand
        {
            Commands.Add(id, typeof(T));
            //CommandsName.Add(id, name);
        }

        public static ICommand GetCommand(string id)
        {
            return (ICommand)Activator.CreateInstance(Commands[id]);
        }
    }
}
