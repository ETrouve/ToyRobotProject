using ToyRobot.Board.Interface;
using ToyRobot.Command.Interface;
using ToyRobot.Robot;
using ToyRobot.Robot.Interface;

namespace ToyRobot.Command
{
    public class RemoteControl : IRemoteControl
    {
        private IRobotSimulator robot;
        private IBoardSimulator board;

        public RemoteControl(IRobotSimulator robot, IBoardSimulator board)
        {
            this.robot = robot;
            this.board = board;
        }

        public void ExecuteCommand(Command command, Position? position)
        {
            switch (command)
            {
                case Command.PLACE:
                    if (position != null)
                    {
                        this.place(position);
                    }
                    else
                    {
                        throw new ArgumentException("You must give a position with \"PLACE\" command");
                    }
                    break;

                case Command.MOVE:
                    this.Move();
                    break;

                case Command.LEFT:
                    this.robot.TurnToLeft();
                    break;

                case Command.RIGHT:
                    this.robot.TurnToRight();
                    break;

                case Command.REPORT:
                    this.ReportPosition();
                    break;
                default:
                    throw new ArgumentException($"Command: {command.ToString("g")} is not correct. Awaited command must be Move, Left, Right, Report or Place X,Y,D where Where X and Y are integers and D must be either NORTH, SOUTH, EAST or WEST");
            }
        }

        public void Move()
        {
            var nextPosition = this.robot.GetNextPostion();

            if (board.ValidateCoordinate(nextPosition.Coordinate))
            {
                this.robot.SetPosition(nextPosition);
            }
        }

        public void place(Position position)
        {
            if (board.ValidateCoordinate(position.Coordinate))
            {
                this.robot.SetPosition(position);
            }
        }

        public void ReportPosition()
        {
            var position = this.robot.GetCurrentPosition();
            Console.Write($"{position.Coordinate.X} {position.Coordinate.Y} {position.Direction.ToString("g")}");
        }
    }
}