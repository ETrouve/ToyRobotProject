namespace ToyRobot.Robot
{
    public class Position {
        public Coordinate Coordinate {get; set;}

        public Direction Direction {get; set;}

        public new string ToString{get {return $"{Coordinate.X}, {Coordinate.Y}, {Direction.ToString("g")}";}}
    }
}