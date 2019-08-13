using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Units;
using AutoChessTD.Events;

namespace AutoChessTD.Interfaces {

    public interface ICapability {

        IList<CommandType> GetAvailableCommands();

        void ExecuteCommand(Command command);
    }

    public abstract class Capability : MonoBehaviour, ICapability {
        
        public Unit Owner { get; protected set; }

        protected List<CommandType> SupportedCommands = new List<CommandType>();

        public virtual void Awake() {
            Owner = GetComponent<Unit>();
        }

        public void ExecuteCommand(Command command) {
            if (command == null || Owner == null) return;

            if (!GetAvailableCommands().Contains(command.GetCommandType())) return;

            Owner.ExecuteCommand(this, command);
        }

        public IList<CommandType> GetAvailableCommands() {
            if (SupportedCommands == null) {
                return new List<CommandType>();
            }

            return SupportedCommands.AsReadOnly();
        }
    }
}
