using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICommand = CommandPattern.Core.Contracts.ICommand;

namespace CommandPattern.InterPreters
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] parts = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = $"{parts[0]}Command";
            string[] commandArgs = parts.Skip(1).ToArray();
            Assembly assembly = Assembly.GetEntryAssembly();
            Type type = assembly?.GetTypes()
                .FirstOrDefault(x=>x.Name==command);
            if (type == null)
            { throw new ArgumentException("Invalid type!"); }
            var instance = (ICommand)Activator.CreateInstance(type);
          return instance?.Execute(commandArgs);
        }
    }
}
