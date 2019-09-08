using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Units;

public class suicideController : MonoBehaviour
{
    [SerializeField] private Unit parent;

    private void OnTriggerEnter(Collider other)
    {

        // triggered for any child gameObject triggers
        
        ICanBeSuicided target = other.GetComponentInParent<ICanBeSuicided>();
        if (target != null && other.tag == "RangeDetection")
        {
            Debug.Log(gameObject.name + " has been triggered by " + other.name);
            target.SuicideDamage(parent.Damage);
            Destroy(parent.gameObject);
        }
    }
}
