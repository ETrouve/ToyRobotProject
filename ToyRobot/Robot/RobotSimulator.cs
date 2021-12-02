using ToyRobot.Robot;
using ToyRobot.Robot.Interface;

namespace ToyRobot.Robot
{
    public class RobotSimulator : IRobotSimulator
    {
        private Direction direction;
        private Coordinate coordinate;
        private Position position 
        {
            get {
                return new Position {
                    Coordinate = coordinate,
                    Direction = direction
                };
            } 
        }

        public RobotSimulator(){
            coordinate = new Coordinate (0,0);
            direction = Direction.NORTH;
        }

        public Position GetNextPostion()
        {
            var nextPosition = new Position{
                Coordinate = new Coordinate(coordinate.X, coordinate.Y),
                Direction = direction
            };

            switch(direction)
            {
                case Direction.NORTH:
                    nextPosition.Coordinate.Y++;
                    break;
                case Direction.EAST:
                    nextPosition.Coordinate.X++;
                    break;
                case Direction.SOUTH:
                    nextPosition.Coordinate.Y--;
                    break;
                case Direction.WEST:
                    nextPosition.Coordinate.X--;
                    break;
                default:
                    Console.WriteLine($"Bad direction {direction.ToString()}");
                    break;
            }

            return nextPosition;
        }

        public void SetPosition(Position position)
        {
           this.coordinate.X = position.Coordinate.X;
           this.coordinate.Y = position.Coordinate.Y;
           this.direction = position.Direction;
        }

        public void TurnToLeft()
        {
            Turn(-1);
        }

        public void TurnToRight()
        {
            Turn(1);
        }

        public Position GetCurrentPosition()
        {
            return position;
        }

        public Coordinate GetCoordinate()
        {
            return coordinate;
        }

        private void Turn(int t){
            var newDirection = direction + t;
            if(newDirection < 0){
                direction = Direction.WEST;
            }else if (newDirection > Direction.WEST){
                direction = Direction.NORTH;            
            }else{
                direction = newDirection;
            }
        }
    }
}