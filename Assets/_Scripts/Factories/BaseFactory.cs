using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoChessTD.Factories {
    public class BaseFactory : MonoBehaviour {

        protected GameObject grid;

        private void Awake() {
            grid = GameManager.Instance.Grid;
        }
    }
}
