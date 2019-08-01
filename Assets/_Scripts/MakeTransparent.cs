using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        var renderers = GetComponentsInChildren<Renderer>(true);
        foreach (var renderer in renderers) {
            for (int i = 0; i < renderer.materials.Length; ++i) {
                var color = renderer.materials[i].GetColor("_BaseColor");
                color.a = 0.5f;
                renderer.materials[i].SetColor("_BaseColor", color);
            }
        }
    }
}
