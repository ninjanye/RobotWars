using RobotWars.Builders;

namespace RobotWars
{
    public interface IContext
    {
        IArena Arena { get; set; }
        IRobot LatestRobot { get; set; }

        IArenaBuilder ArenaBuilder { get; }
        IRobotBuilder RobotBuilder { get; }
    }
}