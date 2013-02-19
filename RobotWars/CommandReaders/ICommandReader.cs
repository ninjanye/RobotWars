using System.Text.RegularExpressions;

namespace RobotWars.CommandReaders
{
    public interface ICommandReader
    {
        bool Validate(string command);
        bool Validate(string command, out Match match);
        void Process(string command);
    }
}