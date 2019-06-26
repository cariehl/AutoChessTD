using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoChessTD.Towers {
    /// <summary>
    /// Generic component that all Towers with have
    /// Contains functionality that all mionions will have
    /// 
    /// Specific towers implemented by creating a prefab variant
    /// with necessary capabilities/commands
    /// </summary>
    public class TowerUnit : MonoBehaviour {

        [Header("Unit")]
        [SerializeField] private float health = 20;
        [SerializeField] private float damage = 5;

        [Header("GameObject")]
        [SerializeField] private float rotationSpeed = 10f;

        public Transform capital;

        [SerializeField] private GameObject _target;
        public GameObject Target {
            get { return _target; }
            private set {
                _target = value;
            }
        }

        private void Start() {

        }

        private void Update() {
            LookAtTarget();
        }

        private void LookAtTarget() {
            if (Target == null) return;

            Vector3 diff = Target.transform.position - capital.position;
            capital.rotation = Quaternion.Slerp(capital.rotation, Quaternion.LookRotation(diff), rotationSpeed * Time.deltaTime);
        }
    } 
}
