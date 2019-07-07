using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Interfaces;
using AutoChessTD.Units;

namespace AutoChessTD.Events {
    /// <summary>
    /// static class containing static delegate/events/event trigger methods
    /// </summary>
    public static class EventManager {
        public delegate void UnitCommandDelegate(Unit unit, ICapability capability, Command command);

        public static event UnitCommandDelegate OnUnitCommandExecuted;

        public static void UnitCommandExecuted(Unit unit, ICapability capability, Command command) {
            OnUnitCommandExecuted?.Invoke(unit, capability, command);
        }
    }
}
