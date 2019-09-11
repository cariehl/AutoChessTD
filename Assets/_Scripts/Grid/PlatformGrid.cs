using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoChessTD.Grid {
    public class PlatformGrid : MonoBehaviour {

        [SerializeField] private GameObject platform;

        public int Width { get; private set; }  // # of cells wide
        public int Height { get; private set; } // # of cells tall
        public float CellSize { get; private set; } // width/height of a cell

        private float widthRadius;
        private float heightRadius;
        private float cellRadius;

        public void Initialize(Vector2 gridSize, float cellSize) {
            Width = (int)gridSize.x;
            Height = (int)gridSize.y;
            CellSize = cellSize;

            widthRadius = (Width * cellSize) / 2f;
            heightRadius = (Height * cellSize) / 2f;
            cellRadius = CellSize / 2f;

            float widthScale = gridSize.x * cellSize;
            float heightScale = gridSize.y * cellSize;

            platform.transform.localScale = new Vector3(widthScale, 1, heightScale);
        }

        /// <summary>
        /// Returns the center of the GridLocation in world space coordinates
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public Vector3 GridLocationToWorldSpace(GridLocation location) {
            return transform.TransformPoint(GridLocationToLocalSpace(location));
        }

        /// <summary>
        /// Returns the center of the GridLocation in local space coordinates
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        private Vector3 GridLocationToLocalSpace(GridLocation location) {
            Vector3 point = new Vector3(-widthRadius, 0, heightRadius);
            point.x += (CellSize * location.GetColumnValue()) + cellRadius;
            point.z -= (CellSize * location.GetRowValue()) + cellRadius;

            return point;
        }
    }
}

