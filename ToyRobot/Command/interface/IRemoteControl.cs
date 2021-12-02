using ToyRobot.Robot;

namespace ToyRobot.Command.Interface
{
    public interface IRemoteControl{
        void ExecuteCommand(Command cmd, Position? position);

        void place(Position position);

        void Move();

        void ReportPosition();
    }
}