using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AutoChessTD.Grid {
    public class PlatformGrid : MonoBehaviour {

        public int Width { get; private set; }
        public int Height { get; private set; }
        public float CellSize { get; private set; }

        private float localWidthIncrement;
        private float localHeightIncrement;

        public void Initialize(Vector2 gridSize, float cellSize) {
            Width = (int)gridSize.x;
            Height = (int)gridSize.y;
            CellSize = cellSize;

            localWidthIncrement = 1f / Width;
            localHeightIncrement = 1f / Height;

            float widthScale = gridSize.x * cellSize;
            float heightScale = gridSize.y * cellSize;

            transform.localScale = new Vector3(widthScale, 1, heightScale);
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
            Vector3 point = new Vector3(-0.5f, 0, 0.5f);
            point.x += localWidthIncrement * location.GetColumnValue();
            point.y -= localHeightIncrement * location.GetRowValue();

            return point;
        }
    }
}

