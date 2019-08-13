using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Units.Commands;

namespace AutoChessTD.Units.Capabilities {

    [RequireComponent(typeof(LineRenderer))]
    public class AutoAttackCapability : Capability {

        [Header("Stats")]
        [SerializeField] private float attackRange = 1f;
        [Tooltip("Number of attacks per second")]
        [Range(0, 10)]
        [SerializeField] private float attackSpeed = 1f;

        [Space]
        [SerializeField] private GameObject laser;

        [SerializeField] private Unit target;

        public List<Unit> knownUnits;

        private float attackDownTime = 1f;

        private LineRenderer lineRenderer;

        private void OnValidate() {
            attackDownTime = 1f / attackSpeed;
        }

        public override void Awake() {
            base.Awake();

            SupportedCommands.Add(CommandType.AUTO_ATTACK);
            lineRenderer = GetComponent<LineRenderer>();
            lineRenderer.enabled = false;
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
            AssignTarget(unit);
        }

        private void OnUnitUndetected(Unit unit) {
            Debug.Log(unit);
            knownUnits.Remove(unit);

            if (target != unit) return;

            target = null;
            FindTargetInRange();
        }

        private void AssignTarget(Unit _target) {
            target = _target;
            target.OnKilled += OnTargetKilled;

            StartCoroutine(AttackTarget());
        }

        private void FindTargetInRange() {
            if (knownUnits.Count == 0) return;

            AssignTarget(knownUnits[0]);
        }

        private void LookAtTarget() {
            Owner.LookAtTarget(target);
        }

        private IEnumerator AttackTarget() {
            StartCoroutine(ShowLaser());
            target.TakeDamage(Owner.Damage);
            yield return new WaitForSeconds(attackDownTime);

            if (target != null)
                StartCoroutine(AttackTarget());
        }

        private IEnumerator ShowLaser() {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, laser.transform.position);
            lineRenderer.SetPosition(1, target.transform.position);
            yield return new WaitForSeconds(0.1f);
            lineRenderer.enabled = false;
        }

        private void OnTargetKilled(Unit unit) {
            target.OnKilled -= OnTargetKilled;
            knownUnits.Remove(unit);
            target = null;

            FindTargetInRange();
        }
    }
}
