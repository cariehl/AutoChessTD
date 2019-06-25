using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoChessTD {

    public class Tower : MonoBehaviour {

        [SerializeField] private float ROTATION_SPEED = 10f;

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
            capital.rotation = Quaternion.Slerp(capital.rotation, Quaternion.LookRotation(diff), ROTATION_SPEED * Time.deltaTime);
        }
    }
}

