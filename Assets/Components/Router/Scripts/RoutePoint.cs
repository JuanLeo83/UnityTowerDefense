using JetBrains.Annotations;
using UnityEngine;

namespace Components.Router.Scripts {
    public class RoutePoint : MonoBehaviour {
        [SerializeField] public int position = 1;
        [SerializeField] [CanBeNull] private RoutePoint nextPoint;

        public bool isEndOfRoute() => nextPoint == null;

        public RoutePoint getNextPoint() => nextPoint;

        public void setNextPoint(RoutePoint next) {
            nextPoint = next;
        }

        public void removePoint() {
            var parent = transform.parent.gameObject;
            var routeCreator = parent.GetComponent<RouteCreator>();
            routeCreator.removePointAndLinkAgain(position);
        }

        private void OnDrawGizmos() {
            Gizmos.color = Color.cyan;
            var pos = transform.position;
            Gizmos.DrawCube(pos, new Vector3(0.25f, 0.25f));

            if (nextPoint is not null) Gizmos.DrawLine(pos, nextPoint.transform.position);
        }
    }
}