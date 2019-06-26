using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoChessTD.Minions {
    /// <summary>
    /// Generic component that all Minions with have
    /// Contains functionality that all mionions will have
    /// 
    /// Specific minions implemented by creating a prefab variant
    /// with necessary capabilities/commands
    /// </summary>
    public class MinionUnit : MonoBehaviour {

        [SerializeField] private float health = 10;
        [SerializeField] private float damage = 1;
    }

}
