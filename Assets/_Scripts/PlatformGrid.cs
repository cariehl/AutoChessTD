using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoChessTD {
    public class PlatformGrid : MonoBehaviour {

        Renderer rend;

        private void Awake() {
            rend = GetComponent<Renderer>();
            rend.material.mainTextureScale = new Vector2(transform.localScale.x, transform.localScale.z);
        }
    }
}

