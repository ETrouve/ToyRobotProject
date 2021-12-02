using Xunit;
using ToyRobot.Command;
using ToyRobot.Command.Interface;
using ToyRobot.Board.Interface;
using ToyRobot.Board;
using ToyRobot.Robot.Interface;
using ToyRobot.Robot;

namespace ToyRobot.Tests
{
    public class RemoteControlTest
    {
        private IRobotSimulator robotSimulator = new RobotSimulator();
        private IBoardSimulator boardSimulator = new BoardSimulator(5);

        [Fact]
        public void PlaceTest()
        {
            var remoteControl = new RemoteControl(robotSimulator, boardSimulator);
            Assert.Equal(0, robotSimulator.GetCoordinate().X);
            Assert.Equal(0, robotSimulator.GetCoordinate().Y);

            remoteControl.ExecuteCommand(Command.Command.PLACE, new Position
                                                                    {
                                                                        Coordinate = new Coordinate(3, 3),
                                                                        Direction = Direction.SOUTH
                                                                    });

            Assert.Equal(3, robotSimulator.GetCoordinate().X);
            Assert.Equal(3, robotSimulator.GetCoordinate().Y);
        }

        [Fact]
        public void MoveTest()
        {
            var remoteControl = new RemoteControl(robotSimulator, boardSimulator);
            Assert.Equal(0, robotSimulator.GetCoordinate().X);
            Assert.Equal(0, robotSimulator.GetCoordinate().Y);
            remoteControl.ExecuteCommand(Command.Command.MOVE, null);
            Assert.Equal(0, robotSimulator.GetCoordinate().X);
            Assert.Equal(1, robotSimulator.GetCoordinate().Y);
        }

        [Fact]
        public void TurnTest()
        {
            var remoteControl = new RemoteControl(robotSimulator, boardSimulator);
            remoteControl.ExecuteCommand(Command.Command.PLACE, new Position
                                                                    {
                                                                        Coordinate = new Coordinate(0, 0),
                                                                        Direction = Direction.NORTH
                                                                    });
            Assert.Equal(0, robotSimulator.GetCoordinate().X);
            Assert.Equal(0, robotSimulator.GetCoordinate().Y);
            
            remoteControl.ExecuteCommand(Command.Command.LEFT, null);
            Assert.Equal(Direction.WEST, robotSimulator.GetCurrentPosition().Direction);

            remoteControl.ExecuteCommand(Command.Command.RIGHT, null);
            Assert.Equal(Direction.NORTH, robotSimulator.GetCurrentPosition().Direction);
        }
    }
}