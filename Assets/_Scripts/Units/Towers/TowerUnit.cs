using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Interfaces;

namespace AutoChessTD.Units.Towers {
    /// <summary>
    /// Generic component that all Towers with have
    /// Contains functionality that all mionions will have
    /// 
    /// Specific towers implemented by creating a prefab variant
    /// with necessary capabilities/commands
    /// </summary>
    public class TowerUnit : Unit {

        [Header("Stats")]
        [SerializeField] private float health = 20;
        [SerializeField] private float damage = 5;

        [Header("GameObject")]
        [SerializeField] private float rotationSpeed = 10f;

        [SerializeField] private Transform capital;

        [SerializeField] private GameObject _target;
        public GameObject Target {
            get { return _target; }
            private set {
                _target = value;
            }
        }

        public override void Awake() {
            base.Awake();
        }

        private void Update() {
            LookAtTarget();
        }

        private void OnCollisionEnter(Collision collision) {
            // triggered for any child gameObject collisions
        }

        private void OnTriggerEnter(Collider other) {
            // triggered for any child gameObject triggers
        }

        private void LookAtTarget() {
            if (Target == null) return;

            Vector3 diff = Target.transform.position - capital.position;
            capital.rotation = Quaternion.Slerp(capital.rotation, Quaternion.LookRotation(diff), rotationSpeed * Time.deltaTime);
        }
    } 
}
