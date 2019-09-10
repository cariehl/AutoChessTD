using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Units.HomeBases;

namespace AutoChessTD.Factories {

    public class HomeBaseFactory : BaseFactory {

        [SerializeField] private HomeBaseUnit homeBasePrefab;

        public HomeBaseUnit SpawnHomeBase() {
            return SpawnHomeBase(grid.transform.position, grid.transform.rotation);
        }

        public HomeBaseUnit SpawnHomeBase(Vector3 position) {
            return SpawnHomeBase(position, grid.transform.rotation);
        }

        public HomeBaseUnit SpawnHomeBase(Vector3 position, Quaternion rotation) {

            var homeBase = Instantiate(homeBasePrefab, position, rotation);

            return homeBase;
        }
    }
}
