using JetBrains.Annotations;
using UnityEngine;

namespace Components.Router {
    public class RoutePoint : MonoBehaviour {
        [SerializeField] private RoutePoint prefab;

        [SerializeField] public int position = 1;
        [SerializeField] [CanBeNull] private RoutePoint nextPoint;

        public bool IsEndOfRoute() {
            return nextPoint == null;
        }

        public void CreateNextPoint() {
            var thisPoint = transform;
            nextPoint = Instantiate(
                prefab,
                thisPoint.position + Vector3.right * 2.5f,
                Quaternion.identity,
                thisPoint);
            if (nextPoint is not null) nextPoint.position = position + 1;
        }

        public RoutePoint GetNextPoint() => nextPoint;

        private void OnDrawGizmos() {
            Gizmos.color = Color.cyan;
            var pos = transform.position;
            Gizmos.DrawCube(pos, new Vector3(0.25f, 0.25f));

            if (nextPoint is not null) Gizmos.DrawLine(pos, nextPoint.transform.position);
        }
    }
}