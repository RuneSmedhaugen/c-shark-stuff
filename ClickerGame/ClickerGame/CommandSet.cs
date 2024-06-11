using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerGame
{
    internal class CommandSet
    {
        private ICommand[] _commands;

        public CommandSet(ClickerGame game)
        {
            _commands = new ICommand[]
            {
                new ExitCommand(),
                new Click(game),
                new Upgrade(game),
                new SuperUpgrade(game),
            };
        }

        public void Run(char CommandChar)
        {
            var command = FindCommand(CommandChar);
            if (command != null) command.Run();
        }

        private ICommand FindCommand(char CommandChar)
        {
            foreach (var command in _commands)
            {
                if (command.Character == CommandChar) return command;
            }

            return null;
        }
    }
}
