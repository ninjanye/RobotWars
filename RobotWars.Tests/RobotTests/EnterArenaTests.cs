using Moq;
using NUnit.Framework;
using RobotWars.Enums;

namespace RobotWars.Tests.RobotTests
{
    [TestFixture]
    public class EnterArenaTests : RobotTestsBase
    {
        [Test]
        public void EnterArena_ValidArena_ArenaPropertySet()
        {
            //Arrange

            //Act
            robot.EnterArena(this.arena.Object, 0, 0, RobotDirection.North);

            //Assert
            Assert.AreSame(arena.Object, robot.Arena);
        }

        [Test]
        public void EnterArena_ValidXCoordinate_RobotLatitudeSet()
        {
            //Arrange

            //Act
            robot.EnterArena(this.arena.Object, validCoordinate, validCoordinate, RobotDirection.North);

            //Assert
            Assert.AreEqual(validCoordinate, robot.Latitude);

        }

        [Test]
        public void EnterArena_ValidYCoordinate_RobotLongitudeSet()
        {
            //Arrange

            //Act
            robot.EnterArena(this.arena.Object, validCoordinate, validCoordinate, RobotDirection.North);

            //Assert
            Assert.AreEqual(validCoordinate, robot.Longitude);
        }

        [Test]
        public void EnterArena_InvalidXCoordinate_ReturnFalse()
        {
            //Arrange

            //Act
            bool success = robot.EnterArena(this.arena.Object, invalidCoordinate, validCoordinate, RobotDirection.North);
            
            //Assert
            Assert.IsFalse(success);
        }

        [Test]
        public void EnterArena_ValidCoordinates_ReturnTrue()
        {
            //Arrange

            //Act
            bool success = robot.EnterArena(this.arena.Object, validCoordinate, validCoordinate, RobotDirection.North);

            //Assert
            Assert.IsTrue(success);
        }

        [Test]
        public void EnterArena_InvalidYCoordinate_ReturnFalse()
        {
            //Arrange

            //Act
            bool success = robot.EnterArena(this.arena.Object, validCoordinate, invalidCoordinate, RobotDirection.North);

            //Assert
            Assert.IsFalse(success);
        }

        [Test]
        public void EnterArena_ArenaIsNull_ReturnFalse()
        {
            //Arrange

            //Act
            bool success = robot.EnterArena(null, validCoordinate, invalidCoordinate, RobotDirection.North);

            //Assert
            Assert.IsFalse(success);
        }

        [Test]
        public void EnterArena_DirectionIsEast_RobotDirectionIsSet()
        {
            //Arrange
            var robotDirection = RobotDirection.East;
            
            //Act
            robot.EnterArena(this.arena.Object, validCoordinate, validCoordinate, robotDirection);

            //Assert
            Assert.AreEqual(robotDirection, robot.Direction);
        }

        [Test]
        public void EnterArena_DirectionIsSouth_RobotDirectionIsSet()
        {
            //Arrange
            var robotDirection = RobotDirection.South;
            
            //Act
            robot.EnterArena(this.arena.Object, validCoordinate, validCoordinate, robotDirection);

            //Assert
            Assert.AreEqual(robotDirection, robot.Direction);
        }
    }
}
