using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoChessTD.Grid {
    public class PlatformGrid : MonoBehaviour {

        Renderer rend;

        private void Awake() {
            //rend = GetComponent<Renderer>();
            //rend.material.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.z);
        }

        public void Initialize(Vector2 gridSize) {
            transform.localScale = new Vector3(gridSize.x, 1, gridSize.y);
        }
    }
}

