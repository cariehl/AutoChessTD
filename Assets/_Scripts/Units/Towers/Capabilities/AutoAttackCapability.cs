using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Interfaces;

namespace AutoChessTD.Units.Towers.Capabilities {

    public class AutoAttackCapability : Capability {

        [SerializeField] private float AttackRange = 1f;

        [SerializeField] private Unit target;

        public List<Unit> knownUnits;

        public override void Awake() {
            base.Awake();

            SupportedCommands.Add(CommandType.AUTO_ATTACK);
        }

        private void OnEnable() {
            Owner.OnUnitDetected += OnUnitDetected;
            Owner.OnUnitUndetected += OnUnitUndetected;
        }

        private void OnDisable() {
            Owner.OnUnitDetected -= OnUnitDetected;
            Owner.OnUnitUndetected -= OnUnitUndetected;
        }

        private void Update() {
            LookAtTarget();
        }

        private void OnUnitDetected(Unit unit) {
            knownUnits.Add(unit);

            if (target != null) return;
            target = unit;
        }

        private void OnUnitUndetected(Unit unit) {
            Debug.Log(unit);
            knownUnits.Remove(unit);

            if (target != unit) return;

            target = null;
            FindTargetInRange();
        }

        private void FindTargetInRange() {
            if (knownUnits.Count == 0) return;

            target = knownUnits[0];
        }

        private void LookAtTarget() {
            Owner.LookAtTarget(target);
        }
    }
}
