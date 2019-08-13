
using AutoChessTD.Units.Capabilities;

namespace AutoChessTD.Units.Commands {

    public sealed class CommandType {
        public readonly string Name;
        public readonly Values Value;

        private CommandType(Values value, string name) {
            Name = name;
            Value = value;
        }

        public enum Values {
            AUTO_ATTACK
        }

        public static readonly CommandType AUTO_ATTACK = new CommandType(Values.AUTO_ATTACK, "Auto Attack");
    }

    public interface ICommand {

        void Execute(ICapability capability);

        string GetCommandName();

        CommandType GetCommandType();
    }

    /// <summary>
    /// Functionality for a Command/Capability implemented in the command's Execute method
    /// </summary>
    public abstract class Command : ICommand {
        public abstract void Execute(ICapability capability);

        public string GetCommandName() {
            return GetCommandType().Name;
        }

        public abstract CommandType GetCommandType();
    }
}

