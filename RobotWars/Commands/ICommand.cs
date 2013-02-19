namespace RobotWars.Commands
{
    public interface ICommand
    {
        bool Execute(char command, IRobot robot);
        bool IsValid(char command);
    }
}