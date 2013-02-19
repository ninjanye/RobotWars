using System;

namespace RobotWars.Enums
{
    [Flags]
    public enum RobotDirection
    {
        North = 1,
        East = 2,
        South = 4,
        West = 8
    }
}