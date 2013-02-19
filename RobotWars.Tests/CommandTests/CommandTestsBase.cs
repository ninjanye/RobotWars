using Moq;
using NUnit.Framework;

namespace RobotWars.Tests.CommandTests
{
    public class CommandTestsBase
    {
        protected Mock<IRobot> robot;

        [SetUp]
        public virtual void Setup()
        {
            this.robot = new Mock<IRobot>();
        }
    }
}