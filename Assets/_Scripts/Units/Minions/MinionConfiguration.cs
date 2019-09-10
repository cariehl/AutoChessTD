using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoChessTD.Units.Minions {
    [System.Serializable]
    public class MinionConfiguration {

        [SerializeField] public MinionType Type;

        public MinionConfiguration() {
            Type = MinionType.GENERIC;
        }
    }
}
