using Moq;
using NUnit.Framework;

namespace RobotWars.Tests.RobotTests
{
    public class RobotTestsBase
    {
        protected Mock<IArena> arena;
        protected Robot robot;
        protected const uint upperCoordinate = 5;
        protected const uint validCoordinate = 3;
        protected const uint invalidCoordinate = 10;

        [SetUp]
        public virtual void Setup()
        {
            this.arena = new Mock<IArena>();
            this.arena.SetupGet(a => a.UpperLatitude).Returns(upperCoordinate);
            this.arena.SetupGet(a => a.UpperLongitude).Returns(upperCoordinate);

            this.robot = new Robot();
        }
    }
}