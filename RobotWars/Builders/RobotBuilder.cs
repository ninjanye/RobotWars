namespace RobotWars.Builders
{
    public class RobotBuilder : IRobotBuilder
    {
        public IRobot Create()
        {
            return new Robot();
        }
    }
}