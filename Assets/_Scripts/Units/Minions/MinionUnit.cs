using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Data;
using AutoChessTD.Interfaces.Interactables;

namespace AutoChessTD.Units.Minions {
    /// <summary>
    /// Generic component that all Minions with have
    /// Contains functionality that all mionions will have
    /// 
    /// Specific minions implemented by creating a prefab variant
    /// with necessary capabilities/commands
    /// </summary>
    public class MinionUnit : Unit, ITowerInteractable {

        [SerializeField] private MinionType _type;

        public MinionType Type {
            get { return _type; }
            private set {
                _type = value;
            }
        }

        [SerializeField] private MinionConfiguration _config;
        
        public MinionConfiguration Config {
            get { return _config; }
            private set {
                _config = value;
                Type = _config.Type;
            }
        }

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

        public void Init(MinionConfiguration config) {
            Config = config;
        }
    }
}
