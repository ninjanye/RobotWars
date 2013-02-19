using Moq;
using NUnit.Framework;
using RobotWars.Enums;

namespace RobotWars.Tests.RobotTests
{
    [TestFixture]
    public class RotateTests : RobotTestsBase
    {
        private void SetDirection(RobotDirection direction)
        {
            this.robot.EnterArena(this.arena.Object, 0, 0, direction);
        }

        [Test]
        public void Rotate_RobotFacingNorth_RobotFacingEast()
        {
            //Arrange
            this.SetDirection(RobotDirection.North);
            
            //Act
            robot.Rotate();

            //Assert
            Assert.AreEqual(RobotDirection.East, robot.Direction);
        }

        [Test]
        public void Rotate_RobotFacingEast_RobotFacingSouth()
        {
            //Arrange
            this.SetDirection(RobotDirection.East);

            //Act
            robot.Rotate();

            //Assert
            Assert.AreEqual(RobotDirection.South, robot.Direction);
        }

        [Test]
        public void Rotate_RobotFacingSouth_RobotFacesWest()
        {
            //Arrange
            this.SetDirection(RobotDirection.South);

            //Act
            robot.Rotate();

            //Assert
            Assert.AreEqual(RobotDirection.West, robot.Direction);
        }

        [Test]
        public void Rotate_RobotFacingWest_RobotFacesNorth()
        {
            //Arrange
            this.SetDirection(RobotDirection.West);

            //Act
            robot.Rotate();

            //Assert
            Assert.AreEqual(RobotDirection.North, robot.Direction);
        }

        [Test]
        public void RotateAnticlockwise_RobotFacingNorth_RobotFacesWest()
        {
            //Arrange
            this.SetDirection(RobotDirection.North);

            //Act
            robot.Rotate(false);

            //Assert
            Assert.AreEqual(RobotDirection.West, robot.Direction);
        }

        [Test]
        public void RotateAnticlockwise_RobotFacingEast_RobotFacesNorth()
        {
            //Arrange
            this.SetDirection(RobotDirection.East);

            //Act
            robot.Rotate(false);

            //Assert
            Assert.AreEqual(RobotDirection.North, robot.Direction);
        }
    }
}
