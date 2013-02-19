using Moq;
using NUnit.Framework;
using RobotWars.Commands;

namespace RobotWars.Tests.CommandTests
{
    [TestFixture]
    public class MoveCommandTests
    {
        private Mock<IRobot> robot;
        private MoveCommand command;

        [SetUp]
        public void Setup()
        {
            this.robot = new Mock<IRobot>();
            this.command = new MoveCommand();
        }

        [Test]
        public void Execute_RobotIsNull_ReturnFalse()
        {
            //Arrange
            
            //Act
            bool result = this.command.Execute('M', null);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Execute_RobotSupplied_ReturnTrue()
        {
            //Arrange
            
            //Act
            bool result = this.command.Execute('M', this.robot.Object);

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Execute_RobotSupplied_MoveCalledOnRobot()
        {
            //Arrange

            //Act
            this.command.Execute('M', this.robot.Object);

            //Assert
            this.robot.Verify(r => r.Move(), Times.Once());
        }

        [Test]
        public void Execute_CommandNotSupplied_ReturnFalse()
        {
            //Arrange
            
            //Act
            var result = this.command.Execute(' ', this.robot.Object);

            //Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValid_PassValidCharacter_ReturnTrue()
        {
            //Arrange
            
            //Act
            var result = this.command.IsValid('M');

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_PassValidLowecaseCharacter_ReturnTrue()
        {
            //Arrange
            
            //Act
            var result = this.command.IsValid('m');

            //Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValid_PassInvalidCharacter_ReturnFalse()
        {
            //Arrange
            
            //Act
            var result = this.command.IsValid('X');

            //Assert
            Assert.IsFalse(result);
        }
    }
}
