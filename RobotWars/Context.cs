using RobotWars.Builders;

namespace RobotWars
{
    public class Context : IContext
    {
        public Context(IArenaBuilder arenaBuilder, IRobotBuilder robotBuilder)
        {
            ArenaBuilder = arenaBuilder;
            RobotBuilder = robotBuilder;
        }

        public IArenaBuilder ArenaBuilder { get; private set; }
        public IRobotBuilder RobotBuilder { get; private set; }

        public IArena Arena { get; set; }
        public IRobot LatestRobot { get; set; }
    }   
}
