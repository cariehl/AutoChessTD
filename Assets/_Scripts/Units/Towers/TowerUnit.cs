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

        [Header("GameObject")]
        [SerializeField] private float rotationSpeed = 20f;

        [SerializeField] private Transform capital;

        public override void Awake() {
            base.Awake();
        }

        // triggered for any child gameObject collisions
        private void OnCollisionEnter(Collision collision) {
            Debug.Log(collision.gameObject);
        }

        public override void LookAtTarget(Unit target) {
            Vector3 targetPosition;

            if (target == null) {
                if (capital.forward == transform.forward) return;

                targetPosition = capital.position + transform.forward;
            } else {
                targetPosition = target.transform.position;
            }

            Vector3 diff = targetPosition - capital.position;
            capital.rotation = Quaternion.Slerp(capital.rotation, Quaternion.LookRotation(diff), rotationSpeed * Time.deltaTime);
        }
    } 
}
