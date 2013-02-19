namespace RobotWars.Commands
{
    public class MoveCommand : ICommand
    {
        public bool Execute(char command, IRobot robot)
        {
            if (robot == null || !this.IsValid(command))
            {
                return false;
            }

            robot.Move();
            return true;
        }

        public bool IsValid(char command)
        {
            return command == 'M' || command == 'm';
        }
    }
}
