using System;
using System.Text.RegularExpressions;
using RobotWars.Enums;
using RobotWars.Loggers;

namespace RobotWars.CommandReaders
{
    public class CreateRobotCommandReader : CommandReader
    {
        private const string latitudeGroupName = "Latitude";
        private const string longitudeGroupName = "Longitude";
        private const string directionGroupName = "Direction";

        private static readonly string regexPattern = string.Format(@"^(?<{0}>\d+) (?<{1}>\d+) (?<{2}>[n|e|s|w])$", latitudeGroupName, longitudeGroupName, directionGroupName);

        public CreateRobotCommandReader(IContext context, ILogger logger)
            : base(regexPattern, context, logger)
        {
        }

        public override void Process(string command)
        {
            Match match;
            if (!this.Validate(command, out match))
            {
                return;
            }

            this.context.LatestRobot = this.context.RobotBuilder.Create();

            if (this.context.LatestRobot == null)
            {
                return;
            }

            uint latitude = Convert.ToUInt32(match.Groups[latitudeGroupName].Value);
            uint longitude = Convert.ToUInt32(match.Groups[longitudeGroupName].Value);
            RobotDirection direction = ConvertToDirection(match.Groups[directionGroupName].Value);

            bool robotCreated = this.context.LatestRobot.EnterArena(this.context.Arena, latitude, longitude, direction);

            string logMessage = String.Format("Robot creation {0}", robotCreated ? "successful" : "failed");
            this.logger.Log(logMessage);
        }

        private RobotDirection ConvertToDirection(string value)
        {
            switch (value.ToLowerInvariant())
            {
                case "e":
                    return RobotDirection.East;
                case "s":
                    return RobotDirection.South;
                case "w":
                    return RobotDirection.West;
                default:
                    return RobotDirection.North;
            }
        }
    }
}