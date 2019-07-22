using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        var renderers = GetComponentsInChildren<Renderer>(true);
        foreach (var renderer in renderers) {
            foreach (var material in renderer.materials) {
                material.color = new Color(material.color.r, material.color.g, material.color.b, 0.5f);
            }
        }
    }
}
