using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Events;
using AutoChessTD.Interfaces;

namespace AutoChessTD.Units {
    
    public abstract class Unit : MonoBehaviour {

        public delegate void CommandExecutionDelegate(ICapability capability, Command command);
        public event CommandExecutionDelegate OnCommandExecuted;

        public List<ICapability> Capabilities { get; private set; }

        public virtual void Awake() {
            Capabilities = new List<ICapability>(GetComponents<Capability>());
        }

        public virtual void ExecuteCommand(Command command) {
            if (command == null) return;

            foreach (ICapability capability in Capabilities) {
                if (capability.GetAvailableCommands().Contains(command.GetCommandType())) {
                    capability.ExecuteCommand(command);
                }
            }
        }

        public virtual void ExecuteCommand(ICapability capability, Command command) {
            if (capability == null || command == null) return;

            command.Execute(capability);

            OnCommandExecuted?.Invoke(capability, command);
            EventManager.UnitCommandExecuted(this, capability, command);
        }
    }
}
