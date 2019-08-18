using System.Linq;
using UnityEngine;
using AutoChessTD.Units.Minions;

namespace AutoChessTD {

    public static class Util {

        /// <summary>
        /// Information about a point in space that the mouse is currently aiming at through a given camera.
        /// </summary>
        public struct MouseTargetPoint {

            /// <summary>
            /// The point in 3D space that the mouse is aiming at.
            /// </summary>
            public Vector3 point;

            /// <summary>
            /// The collider that the mouse is aiming at. If this is null, it means there is no object within range.
            /// </summary>
            public Collider collider;
        }

        /// <summary>
        /// Get the 3D world coordinates of the mouse relative to the given camera.
        /// </summary>
        /// <param name="camera">Camera to use for determining mouse coordinates.</param>
        /// <param name="layerMask">Layer mask to use for targeting.</param>
        /// <returns>Raycast information about the mouse's target in 3D space.</returns>
        public static MouseTargetPoint GetMouseTargetingPoint(this Camera camera, int layerMask = 0) {
            // Raycast out from the camera and see where we hit.
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            bool hitSuccess = Physics.Raycast(ray, out RaycastHit hit, 1000f, ~layerMask);

            // Convert to results object.
            return new MouseTargetPoint { point = hit.point, collider = hitSuccess ? hit.collider : null };
        }

        /// <summary>
        /// Get this vector with all coordinates floored to the next-lowest whole number.
        /// </summary>
        public static Vector3 Floor(this Vector3 vec) {
            return new Vector3((int)vec.x, (int)vec.y, (int)vec.z);
        }

        /// <summary>
        /// Get this vector with all coordinates ceiled to the next-highest whole number.
        /// </summary>
        public static Vector3 Ceil(this Vector3 vec) {
            return new Vector3((int)(vec.x + 1), (int)(vec.y + 1), (int)(vec.z + 1));
        }

        /// <summary>
        /// Get the first MinionUnit in the array with type or null if non found
        /// </summary>
        /// <param name="array"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MinionUnit GetByType(this MinionUnit[] array, MinionType type) {

            return array.FirstOrDefault(m => m.Type == type);
        }

        public static bool In<T> (this T val, params T[] values) where T : struct {
            return values.Contains(val);
        }
    }
}
