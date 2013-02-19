using Moq;
using NUnit.Framework;
using RobotWars.Builders;
using RobotWars.CommandReaders;
using RobotWars.Enums;

namespace RobotWars.Tests.CommandReadersTests.CreateRobotCommandReaderTests
{
    [TestFixture]
    public class ProcessTests
    {
        const uint latitude = 1;
        const uint longitude = 2;
        const uint largeLatitude = 10;
        const uint largeLongitude = 20;
        
        private Mock<IContext> context;
        private Mock<IArena> arena;
        private Mock<IRobotBuilder> robotBuilder;
        private CreateRobotCommandReader createRobotCommandReader;
        private Mock<IRobot> robot;


        [SetUp]
        public void Setup()
        {
            this.context = new Mock<IContext>();
            this.arena = new Mock<IArena>();

            this.context.SetupGet(c => c.Arena).Returns(this.arena.Object);
            this.context.SetupProperty(c => c.LatestRobot);

            this.robotBuilder = new Mock<IRobotBuilder>();
            this.context.SetupGet(c => c.RobotBuilder).Returns(this.robotBuilder.Object);

            this.robot = new Mock<IRobot>();
            this.robotBuilder.Setup(rb => rb.Create())
                             .Returns(this.robot.Object);


            this.createRobotCommandReader = new CreateRobotCommandReader(this.context.Object);
        }

        private string BuildCommand(uint lat, uint lng, RobotDirection direction)
        {
            string stringDirection;
            switch (direction)
            {
                case RobotDirection.North:
                    stringDirection = "N";
                    break;
                case RobotDirection.South:
                    stringDirection = "S";
                    break;
                case RobotDirection.East:
                    stringDirection = "E";
                    break;
                default:
                    stringDirection = "W";
                    break;
            }

            return string.Format("{0} {1} {2}", lat, lng, stringDirection);
        }

        [Test]
        public void ProcessCreateRobotCommand_TwoDigitsAndADirectionSupplied_CreateRobot()
        {
            //Arrange
            string command = this.BuildCommand(1, 2, RobotDirection.North);

            //Act
            this.createRobotCommandReader.Process(command);

            //Assert
            this.robotBuilder.Verify(rb => rb.Create(), Times.Once());
        }

        [Test]
        public void ProcessCreateRobotCommand_ValidCommandSent_RobotEntersArena()
        {
            //Arrange
            const RobotDirection robotDirection = RobotDirection.North;
            string command = this.BuildCommand(latitude, longitude, robotDirection);

            //Act
            this.createRobotCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.EnterArena(this.arena.Object, It.IsAny<uint>(), It.IsAny<uint>(), It.IsAny<RobotDirection>()), Times.Once());
        }

        [Test]
        public void ProcessCreateRobotCommand_TwoDigitsAndADirectionSupplied_EnterArenaWithCorrectLatitude()
        {
            //Arrange
            string command = this.BuildCommand(latitude, 2, RobotDirection.North);

            //Act
            this.createRobotCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.EnterArena(It.IsAny<IArena>(), latitude, It.IsAny<uint>(), It.IsAny<RobotDirection>()));
        }

        [Test]
        public void ProcessCreateRobotCommand_TwoLargeDigitsAndADirectionSupplied_EnterArenaWithCorrectLatitude()
        {
            //Arrange
            string command = this.BuildCommand(largeLatitude, largeLongitude, RobotDirection.North);

            //Act
            this.createRobotCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.EnterArena(It.IsAny<IArena>(), largeLatitude, It.IsAny<uint>(), It.IsAny<RobotDirection>()));
        }

        [Test]
        public void ProcessCreateRobotCommand_TwoLargeDigitsAndADirectionSupplied_EnterArenaWithCorrectLongitude()
        {
            //Arrange
            string command = this.BuildCommand(largeLatitude, largeLongitude, RobotDirection.North);

            //Act
            this.createRobotCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.EnterArena(It.IsAny<IArena>(), It.IsAny<uint>(), largeLongitude, It.IsAny<RobotDirection>()));
        }

        [Test]
        public void ProcessCreateRobotCommand_ALetterADigitsAndADirectionSupplied_DoNotCreateRobot()
        {
            //Arrange
            string command = "A 20 N";

            //Act
            this.createRobotCommandReader.Process(command);

            //Assert
            this.robotBuilder.Verify(rb => rb.Create(), Times.Never());
        }

        [Test]
        public void ProcessCreateRobotCommand_ValidCommandSent_EnterArenaWithCorrectLongitude()
        {
            //Arrange
            string command = this.BuildCommand(latitude, longitude, RobotDirection.North);

            //Act
            this.createRobotCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.EnterArena(It.IsAny<IArena>(), It.IsAny<uint>(), longitude, It.IsAny<RobotDirection>()));
        }

        [Test]
        public void ProcessCreateRobotCommand_ValidCommandSentForSouth_EnterArenaWithCorrectDirection()
        {
            //Arrange
            const RobotDirection robotDirection = RobotDirection.South;
            string command = this.BuildCommand(latitude, longitude, robotDirection);

            //Act
            this.createRobotCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.EnterArena(It.IsAny<IArena>(), It.IsAny<uint>(), It.IsAny<uint>(), robotDirection));
        }

        [Test]
        public void ProcessCreateRobotCommand_ValidCommandSentForEast_EnterArenaWithCorrectDirection()
        {
            //Arrange
            const RobotDirection robotDirection = RobotDirection.East;
            string command = this.BuildCommand(latitude, longitude, robotDirection);

            //Act
            this.createRobotCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.EnterArena(It.IsAny<IArena>(), It.IsAny<uint>(), It.IsAny<uint>(), robotDirection));
        }

        [Test]
        public void ProcessCreateRobotCommand_ValidCommandSentForWest_EnterArenaWithCorrectDirection()
        {
            //Arrange
            const RobotDirection robotDirection = RobotDirection.West;
            string command = this.BuildCommand(latitude, longitude, robotDirection);

            //Act
            this.createRobotCommandReader.Process(command);

            //Assert
            this.robot.Verify(r => r.EnterArena(It.IsAny<IArena>(), It.IsAny<uint>(), It.IsAny<uint>(), robotDirection));
        }

        [Test]
        public void ProcessCreateRobotCommand_InvalidDirectionSent_RobotNotCreated()
        {
            //Arrange
            string command = "10 20 F";

            //Act
            this.createRobotCommandReader.Process(command);

            //Assert
            this.robotBuilder.Verify(rb => rb.Create(), Times.Never());
        }

        [Test]
        public void ProcessCreateRobotCommand_ValidCommandSent_RobotSaved()
        {
            //Arrange
            const RobotDirection robotDirection = RobotDirection.North;
            string command = this.BuildCommand(latitude, longitude, robotDirection);

            //Act
            this.createRobotCommandReader.Process(command);

            //Assert
            Assert.AreSame(this.robot.Object, this.context.Object.LatestRobot);
        }

    }
}
