using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Interfaces.Interactables;
using AutoChessTD.Interfaces;

namespace AutoChessTD.Units.Minions {
    /// <summary>
    /// Generic component that all Minions with have
    /// Contains functionality that all mionions will have
    /// 
    /// Specific minions implemented by creating a prefab variant
    /// with necessary capabilities/commands
    /// </summary>
    public class MinionUnit : Unit, ITowerInteractable {

        private Vector3 Destination;
        public PlayerController controller;

        public override void Awake() {
            base.Awake();
        }

        private void OnCollisionEnter(Collision collision) {
            // triggered for any child gameObject collisions
        }

        private void OnTriggerEnter(Collider other) {
            // triggered for any child gameObject triggers

            ICanBeSuicided target = other.GetComponentInParent<ICanBeSuicided>();
            if (target != null)
            {
                target.SuicideDamage(Damage);
                Destroy(gameObject);
            }
        }

        public void SetDestination(Vector3 destination)
        {
            controller.SetDestination(destination);
        }
    }
}
