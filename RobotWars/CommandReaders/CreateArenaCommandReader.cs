using System;
using System.Text.RegularExpressions;
using RobotWars.Builders;
using RobotWars.Loggers;

namespace RobotWars.CommandReaders
{
    public class CreateArenaCommandReader : CommandReader
    {
        private const string latitudeGroupName = "Latitude";
        private const string longitudeGroupName = "Longitude";
        private static readonly string regexPattern = String.Format(@"^(?<{0}>\d+) (?<{1}>\d+)$", latitudeGroupName, longitudeGroupName);

        public CreateArenaCommandReader(IContext context, ILogger logger)
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

            uint latitude = Convert.ToUInt32(match.Groups[latitudeGroupName].Value);
            uint longitude = Convert.ToUInt32(match.Groups[longitudeGroupName].Value);
            this.context.Arena = this.context.ArenaBuilder.Create(latitude, longitude);

            this.logger.Log(this.context.Arena != null ? "Arena creation successful" 
                                                       : "Arena creation failed");
        }
    }
}