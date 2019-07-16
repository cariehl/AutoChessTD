using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Events;
using AutoChessTD.Interfaces;

namespace AutoChessTD.Units {
    
    public abstract class Unit : MonoBehaviour {

        public delegate void CommandExecutionDelegate(ICapability capability, Command command);
        public event CommandExecutionDelegate OnCommandExecuted;

        public delegate void UnitDelegate(Unit unit);

        public event UnitDelegate OnUnitDetected;
        public event UnitDelegate OnUnitUndetected;

        [Header("Stats")]
        [SerializeField] private float health = 20;
        [SerializeField] private float damage = 5;
        [SerializeField] private int detectionRange = 0;

        [Space]
        [SerializeField] private float baseDetectionRangeModifier = 1;

        public List<ICapability> Capabilities { get; private set; }

        public BoxCollider rangeDetectionCollider;

        public virtual void Awake() {
            Capabilities = new List<ICapability>(GetComponents<Capability>());
            InitRangeDetection();
        }

        // triggered for any child gameObject triggers
        private void OnTriggerEnter(Collider other) {
            if (other.tag == "RangeDetection") return;

            Unit unit = other.GetComponentInParent<Unit>();
            if (unit == null) return;

            OnUnitDetected?.Invoke(unit);
        }

        private void OnTriggerExit(Collider other) {
            if (other.tag == "RangeDetection") return;

            Unit unit = other.GetComponentInParent<Unit>();
            if (unit == null) return;

            OnUnitUndetected?.Invoke(unit);
        }

        private void InitRangeDetection() {
            rangeDetectionCollider.isTrigger = true;

            float range = (detectionRange + 1) * baseDetectionRangeModifier;
            rangeDetectionCollider.size = new Vector3(range, 1, range);
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

        public virtual void LookAtTarget(Unit target) { }
    }
}
