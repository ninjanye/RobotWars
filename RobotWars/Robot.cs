using RobotWars.Enums;

namespace RobotWars
{
    public class Robot : IRobot
    {
        public Robot()
        {
            this.Direction = RobotDirection.North;
        }

        public RobotDirection Direction { get; private set; }
        public uint Latitude { get; private set; }
        public uint Longitude { get; private set; }
        public IArena Arena { get; set; }

        /// <summary>
        /// Move robot forward 1 unit
        /// </summary>
        public void Move()
        {
            if (this.Arena == null)
            {
                return;
            }

            switch (Direction)
            {
                case RobotDirection.North:
                    if (this.Longitude < this.Arena.UpperLongitude)
                    {
                        this.Longitude++;
                    }
                    break;
                case RobotDirection.East:
                    if (this.Latitude < this.Arena.UpperLatitude)
                    {
                        this.Latitude++;
                    }
                    break;
                case RobotDirection.South:
                    if (this.Longitude > 0)
                    {
                        this.Longitude--;                        
                    }
                    break;
                case RobotDirection.West:
                    if (this.Latitude > 0)
                    {
                        this.Latitude--;
                    }
                    break;
            }
        }

        /// <summary>
        /// Rotate the robot clockwise or anticlockwise
        /// </summary>
        public void Rotate(bool clockwise = true)
        {
            if (clockwise)
            {
                this.Direction = this.Direction == RobotDirection.West ? RobotDirection.North 
                                                                       : (RobotDirection) (((int) this.Direction) << 1);
            }
            else
            {
                this.Direction = this.Direction == RobotDirection.North ? RobotDirection.West 
                                                                        : (RobotDirection) (((int) this.Direction) >> 1);
            }
        }

        /// <summary>
        /// Enter an arena and go to a specified location 
        /// </summary>
        /// <param name="arena">Arena to enter</param>
        /// <param name="x">X coordinate (latitude)</param>
        /// <param name="y">Y coordinate (longitude)</param>
        /// <param name="direction"></param>
        /// <returns>True if arena entered successfully, otherwise false</returns>
        public bool EnterArena(IArena arena, uint x, uint y, RobotDirection direction)
        {
            if (arena == null || x > arena.UpperLatitude || y > arena.UpperLongitude)
            {
                return false;
            }

            this.Arena = arena;
            this.Latitude = x;
            this.Longitude = y;
            this.Direction = direction;

            return true;
        }
    }
}