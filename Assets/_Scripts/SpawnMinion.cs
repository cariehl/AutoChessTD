using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Utility;

namespace AutoChessTD {

    public class SpawnMinion : MonoBehaviour {

        [SerializeField] private GameObject grid;
        [SerializeField] private GameObject minionPrefab;
        [SerializeField] private KeyCode spawnKey;

        void Update() {
            if (Input.GetKeyDown(spawnKey)) {
                var gridPos = Camera.main.GetMouseTargetingPoint(grid.layer);
                Instantiate(minionPrefab, gridPos.point, grid.transform.rotation);
            }
        }
    }
}