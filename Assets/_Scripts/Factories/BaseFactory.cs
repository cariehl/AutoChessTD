using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Grid;

namespace AutoChessTD.Factories {
    public class BaseFactory : MonoBehaviour {

        protected PlatformGrid grid;

        private void Awake() {
            grid = GameManager.Instance.Grid;
        }
    }
}
