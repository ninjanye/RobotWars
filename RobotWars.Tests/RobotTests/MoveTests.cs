using NUnit.Framework;
using RobotWars.Enums;

namespace RobotWars.Tests.RobotTests
{
    [TestFixture]
    public class MoveTests : RobotTestsBase
    {
        [Test]
        public void Move_RobotNotInArena_NoMovement()
        {
            //Arrange
            
            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(0, this.robot.Longitude);
            Assert.AreEqual(0, this.robot.Latitude);
        }

        [Test]
        public void Move_RobotFacingNorth_RobotLongitudeIncreasesByOne()
        {
            //Arrange
            this.robot.EnterArena(this.arena.Object, 0, 0, RobotDirection.North);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(1, this.robot.Longitude);
        }

        [Test]
        public void Move_RobotFacingEast_RobotLatitiudeIncreasesByOne()
        {
            //Arrange
            this.robot.EnterArena(this.arena.Object, 0, 0, RobotDirection.East);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(1, this.robot.Latitude);
        }

        [Test]
        public void Move_RobotFacingSouth_LongitudeDecreasesByOne()
        {
            //Arrange
            this.robot.EnterArena(this.arena.Object, upperCoordinate, upperCoordinate, RobotDirection.South);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(upperCoordinate - 1, this.robot.Longitude);
        }

        [Test]
        public void Move_RobotFacingWest_RobotLatitiudeDecreasesByOne()
        {
            //Arrange
            this.robot.EnterArena(this.arena.Object, upperCoordinate, upperCoordinate, RobotDirection.West);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(upperCoordinate - 1, this.robot.Latitude);
        }

        [Test]
        public void Move_RobotOnLeftEdgeOfArenaFacingWest_RobotDoesNotMove()
        {
            //Arrange
            this.robot.EnterArena(this.arena.Object, 0, 0, RobotDirection.West);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(0, this.robot.Latitude);
        }

        [Test]
        public void Move_RobotOnBottomEdgeOfArenaFacingSouth_RobotDoesNotMove()
        {
            //Arrange
            this.robot.EnterArena(this.arena.Object, 0, 0, RobotDirection.South);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(0, this.robot.Longitude);
        }

        [Test]
        public void Move_RobotOnTopEdgeOfArenaFacingNorth_RobotDoesNotMove()
        {
            //Arrange
            this.robot.EnterArena(this.arena.Object, upperCoordinate, upperCoordinate, RobotDirection.North);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(upperCoordinate, this.robot.Longitude);
        }

        [Test]
        public void Move_RobotOnRightEdgeOfArenaFacingEast_RobotDoesNotMove()
        {
            //Arrange
            this.robot.EnterArena(this.arena.Object, upperCoordinate, upperCoordinate, RobotDirection.East);

            //Act
            this.robot.Move();

            //Assert
            Assert.AreEqual(upperCoordinate, this.robot.Latitude);
        }
    }
}
