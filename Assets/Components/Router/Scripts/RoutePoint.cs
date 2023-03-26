using JetBrains.Annotations;
using UnityEngine;

namespace Components.Router.Scripts {
    public class RoutePoint : MonoBehaviour {
        [SerializeField] public int position = 1;
        [SerializeField] [CanBeNull] private RoutePoint nextPoint;

        public bool IsEndOfRoute() => nextPoint == null;

        public RoutePoint GetNextPoint() => nextPoint;

        public void SetNextPoint(RoutePoint next) {
            nextPoint = next;
        }

        public void RemovePoint() {
            var parent = transform.parent.gameObject;
            var routeCreator = parent.GetComponent<RouteCreator>();
            routeCreator.RemovePointAndLinkAgain(position);
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.cyan;
            var pos = transform.position;
            Gizmos.DrawCube(pos, new Vector3(0.25f, 0.25f));

            if (nextPoint is not null) Gizmos.DrawLine(pos, nextPoint.transform.position);
        }
    }
}