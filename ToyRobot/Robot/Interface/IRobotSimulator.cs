namespace ToyRobot.Robot.Interface {
    public interface IRobotSimulator {
        void SetPosition(Position position);

        Coordinate GetCoordinate();

        Position GetCurrentPosition();

        Position GetNextPostion();

        void TurnToLeft();

        void TurnToRight();
    }
}