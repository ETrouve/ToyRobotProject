using Xunit;
using ToyRobot.Robot;
using ToyRobot.Robot.Interface;
using System;

namespace ToyRobot.Tests
{
    public class RobotSimulatorTest
    {
        private IRobotSimulator robotSimulator = new RobotSimulator();

        [Fact]
        public void GetNextPostionTest()
        {
            robotSimulator.SetPosition(new Position
            {
                Coordinate = new Coordinate(0, 0),
                Direction = Direction.NORTH
            });

            Assert.Equal(Direction.NORTH, robotSimulator.GetCurrentPosition().Direction);
            Assert.Equal(0, robotSimulator.GetCoordinate().X);
            Assert.Equal(0, robotSimulator.GetCoordinate().Y);

            var nextPosition = robotSimulator.GetNextPostion();

            Assert.Equal(0, robotSimulator.GetCoordinate().X);
            Assert.Equal(0, robotSimulator.GetCoordinate().Y);
            Assert.NotNull(nextPosition);
            Assert.Equal(0, nextPosition.Coordinate.X);
            Assert.Equal(1, nextPosition.Coordinate.Y);

            robotSimulator.TurnToRight();

            var otherNextPosition = robotSimulator.GetNextPostion();
            Assert.NotNull(otherNextPosition);
            Assert.Equal(1, otherNextPosition.Coordinate.X);
            Assert.Equal(0, otherNextPosition.Coordinate.Y);
        }

        [Fact]
        public void TurnToLeftTest()
        {
            robotSimulator.SetPosition(new Position
            {
                Coordinate = new Coordinate(0, 0),
                Direction = Direction.NORTH
            });

            Assert.Equal(Direction.NORTH, robotSimulator.GetCurrentPosition().Direction);
            Assert.Equal(0, robotSimulator.GetCoordinate().X);
            Assert.Equal(0, robotSimulator.GetCoordinate().Y);
            robotSimulator.TurnToLeft();
            Assert.Equal(Direction.WEST, robotSimulator.GetCurrentPosition().Direction);
            robotSimulator.TurnToLeft();
            Assert.Equal(Direction.SOUTH, robotSimulator.GetCurrentPosition().Direction);
            robotSimulator.TurnToLeft();
            Assert.Equal(Direction.EAST, robotSimulator.GetCurrentPosition().Direction);
            robotSimulator.TurnToLeft();
            Assert.Equal(Direction.NORTH, robotSimulator.GetCurrentPosition().Direction);
            robotSimulator.TurnToLeft();
            Assert.Equal(Direction.WEST, robotSimulator.GetCurrentPosition().Direction);
        }

        [Fact]
        public void TurnToRightTest()
        {
            robotSimulator.SetPosition(new Position
            {
                Coordinate = new Coordinate(0, 0),
                Direction = Direction.NORTH
            });

            Assert.Equal(Direction.NORTH, robotSimulator.GetCurrentPosition().Direction);
            Assert.Equal(0, robotSimulator.GetCoordinate().X);
            Assert.Equal(0, robotSimulator.GetCoordinate().Y);
            
            robotSimulator.TurnToRight();
            Assert.Equal(Direction.EAST, robotSimulator.GetCurrentPosition().Direction);
            robotSimulator.TurnToRight();
            Assert.Equal(Direction.SOUTH, robotSimulator.GetCurrentPosition().Direction);
            robotSimulator.TurnToRight();
            Assert.Equal(Direction.WEST, robotSimulator.GetCurrentPosition().Direction);
            robotSimulator.TurnToRight();
            Assert.Equal(Direction.NORTH, robotSimulator.GetCurrentPosition().Direction);
            robotSimulator.TurnToRight();
            Assert.Equal(Direction.EAST, robotSimulator.GetCurrentPosition().Direction);
        }
    }
}