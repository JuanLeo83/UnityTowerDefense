using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Components.Router.Scripts {
    public class RouteCreator : MonoBehaviour {
        public static readonly string RoutePointTag = "RoutePoint";
        
        [SerializeField] private RoutePoint prefab;
        [SerializeField] private List<RoutePoint> points;

        public void createNextPoint() {
            points ??= new List<RoutePoint>();

            var lastPointAdded = points.Count > 0 ? points.Last() : null;

            var parentTransform = transform;
            var nextPointPosition = lastPointAdded != null
                ? lastPointAdded.transform.position + Vector3.right * 2.5f
                : parentTransform.position;

            var nextPoint = Instantiate(
                prefab,
                nextPointPosition,
                Quaternion.identity,
                parentTransform);

            if (nextPoint is null) return;

            nextPoint.position = points.Count + 1;
            nextPoint.tag = RoutePointTag;
            if (lastPointAdded is not null) lastPointAdded.setNextPoint(nextPoint);
            points.Add(nextPoint);
        }

        public IEnumerable<RoutePoint> getPoints() => points;

        public void removePointAndLinkAgain(int position) {
            var element = points.Find(point => point.position == position);

            if (position > 1) {
                points[position - 2].setNextPoint(element.isEndOfRoute() ? null : points[position]);
            }

            points.Remove(element);
            DestroyImmediate(element.gameObject);

            var counter = 0;
            foreach (var point in points) {
                point.position = counter + 1;
                counter++;
            }
        }
    }
}