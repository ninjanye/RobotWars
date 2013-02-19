using System.Collections.Generic;
using System.Linq;
using RobotWars.Commands;
using RobotWars.Loggers;

namespace RobotWars.CommandReaders
{
    public class MoveRobotCommandReader : CommandReader
    {
        private readonly IList<ICommand> commands;

        public MoveRobotCommandReader(IContext context, IEnumerable<ICommand> commands, ILogger logger )
            : base("^[m|r|l]+$", context, logger)
        {
            this.commands = commands.ToList();
        }

        public override void Process(string command)
        {
            if (!this.Validate(command))
            {
                return;
            }

            IRobot robot = this.context.LatestRobot;
            foreach (var character in command.ToLowerInvariant())
            {
                ICommand executer = GetExecuter(character);
                executer.Execute(character, robot);
            }

            this.logger.Log("Robot movement completed");
            this.logger.Log(string.Format("Robot Position: {0} {1} {2}", robot.Latitude, robot.Longitude, robot.Direction));
        }

        private ICommand GetExecuter(char character)
        {
            return this.commands.FirstOrDefault(command => command.IsValid(character));
        }
    }
}