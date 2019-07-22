using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AutoChessTD.Utility;

namespace AutoChessTD {

    public class TowerPlacement : MonoBehaviour {

        [SerializeField] private GameObject grid;
        [SerializeField] private GameObject towerModelPrefab;
        [SerializeField] private GameObject towerPrefab;
        [SerializeField] private KeyCode spawnKey;

        private Coroutine activeTowerPlacement;

        void Start() {

        }

        void Update() {
            if (Input.GetKeyDown(spawnKey)) {
                if (activeTowerPlacement != null) {
                    StopCoroutine(activeTowerPlacement);
                }

                activeTowerPlacement = StartCoroutine(PlaceTower(towerPrefab));
            }
        }

        IEnumerator PlaceTower(GameObject tower) {
            // Create the ghost model.
            GameObject model = Instantiate(towerModelPrefab);
            model.transform.rotation = grid.transform.rotation;

            // Make each renderer in the ghost model transparent.
            model.AddComponent<MakeTransparent>();

            while (true) {
                Util.MouseTargetPoint target = Camera.main.GetMouseTargetingPoint(grid.layer);
                Vector3 targetPoint = target.point;

                var relativeGridPosition = targetPoint - grid.transform.position;
                var gridCoords = relativeGridPosition.Floor();

                // Left-click spawns the tower.
                if (Input.GetMouseButtonDown(0)) {
                    Instantiate(towerPrefab, model.transform.position, model.transform.rotation);
                    Destroy(model);

                    yield break;
                }

                // If we didn't spawn the tower, move the model to match the mouse position.
                var gridCoordsWorldSpace = gridCoords + grid.transform.position;
                model.transform.position = gridCoordsWorldSpace;

                yield return null;
            }
        }
    }
}