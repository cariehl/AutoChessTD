using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Data;
using AutoChessTD.Units;
using AutoChessTD.Units.Minions;

namespace AutoChessTD.Factories {

    public class MinionFactory : BaseFactory {

        public MinionUnit[] unitPrefabs;

        public MinionUnit SpawnMinion(Vector3 position) {
            return SpawnMinion(new MinionConfiguration(), position);
        }

        public MinionUnit SpawnMinion(MinionConfiguration minionConfig) {
            return SpawnMinion(minionConfig, grid.transform.position, grid.transform.rotation);
        }

        public MinionUnit SpawnMinion(MinionConfiguration minionConfig, Vector3 position) {
            return SpawnMinion(minionConfig, position, grid.transform.rotation);
        }

        public MinionUnit SpawnMinion(MinionConfiguration minionConfig, Vector3 position, Quaternion rotation) {

            var prefab = unitPrefabs.GetByType(minionConfig.Type);
            if (prefab == null) return null;

            var minion = Instantiate<MinionUnit>(prefab, position, rotation);
            minion.Init(minionConfig);

            return minion;
        }
    }
}
