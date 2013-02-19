using System;
using System.Linq;
using Ninject;
using RobotWars.Builders;
using RobotWars.CommandReaders;
using RobotWars.Commands;
using RobotWars.Loggers;

namespace RobotWars.Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            BuildDependencies(kernel);

            var commandReaders = kernel.GetAll<ICommandReader>().ToList();

            bool exit = false;
            while (!exit)
            {
                var command = Console.ReadLine();
                if (command == "exit" || command == "quit")
                {
                    exit = true;
                    continue;
                }

                foreach (var commandReader in commandReaders)
                {
                    if (!commandReader.Validate(command))
                    {
                        continue;
                    }

                    commandReader.Process(command);
                    break;
                }
            }
        }

        private static void BuildDependencies(IKernel kernel)
        {
            kernel.Bind<IContext>().To<Context>().InThreadScope();
            kernel.Bind<IArenaBuilder>().To<ArenaBuilder>();
            kernel.Bind<IRobotBuilder>().To<RobotBuilder>();
            kernel.Bind<ILogger>().To<CommandLineLogger>();

            RegisterCommandReaders(kernel);
            RegisterCommands(kernel);
        }

        private static void RegisterCommandReaders(IKernel kernel)
        {
            kernel.Bind<ICommandReader>().To<CreateArenaCommandReader>();
            kernel.Bind<ICommandReader>().To<CreateRobotCommandReader>();
            kernel.Bind<ICommandReader>().To<MoveRobotCommandReader>();
        }

        private static void RegisterCommands(IKernel kernel)
        {
            kernel.Bind<ICommand>().To<MoveCommand>();
            kernel.Bind<ICommand>().To<RotateCommand>();
        }
    }
}
