
using AutoChessTD.Units;
using AutoChessTD.Units.Capabilities;
using AutoChessTD.Units.Commands;

namespace AutoChessTD.Events {
    /// <summary>
    /// static class containing static delegate/events/event trigger methods
    /// </summary>
    public static class EventManager {
        public delegate void UnitCommandDelegate(Unit unit, ICapability capability, Command command);

        public static event UnitCommandDelegate OnUnitCommandExecuted;

        public delegate void VoidDelegate();
        public delegate void BoolDelegate(bool success);

        public static event VoidDelegate OnScenarioStarted;
        public static event BoolDelegate OnScenarioEnded;

        public static event VoidDelegate OnRoundStarted;
        public static event BoolDelegate OnRoundEnded;

        public static void UnitCommandExecuted(Unit unit, ICapability capability, Command command) {
            OnUnitCommandExecuted?.Invoke(unit, capability, command);
        }

        public static void ScenarioStarted() {
            OnScenarioStarted?.Invoke();
        }

        public static void ScenarioEnded(bool success) {
            OnScenarioEnded?.Invoke(success);
        }

        public static void RoundStarted() {
            OnRoundStarted?.Invoke();
        }

        public static void RoundEnded(bool success=true) {
            OnRoundEnded?.Invoke(success);
        }
    }
}
