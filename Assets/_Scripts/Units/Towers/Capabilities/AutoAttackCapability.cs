using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Interfaces;

namespace AutoChessTD.Units.Towers.Capabilities {

    public class AutoAttackCapability : Capability {

        public float AttackRange = 1f;

        public override void Awake() {
            SupportedCommands.Add(CommandType.AUTO_ATTACK);
        }
    }
}
