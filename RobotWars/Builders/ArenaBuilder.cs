namespace RobotWars.Builders
{
    public class ArenaBuilder : IArenaBuilder
    {
        public IArena Create(uint latitude, uint longitude)
        {
            return new Arena(latitude, longitude);
        }
    }
}