using UnityEditor;
using UnityEngine;

namespace Components.Router {
    [CustomEditor(typeof(RoutePoint))]
    public class RoutePointEditor : Editor {
        private RoutePoint RoutePoint => target as RoutePoint;

        private void OnSceneGUI() {
            EditorGUI.BeginChangeCheck();

            var textStyle = new GUIStyle {
                fontStyle = FontStyle.Bold,
                fontSize = 18,
                normal = {textColor = Color.cyan}
            };

            var textAlign = Vector3.down * 0.3f + Vector3.left * 0.1f;
            Handles.Label(RoutePoint.transform.position + textAlign, RoutePoint.position.ToString(), textStyle);

            EditorGUI.EndChangeCheck();
        }

        public override void OnInspectorGUI() {
            DrawDefaultInspector();
            if (GUILayout.Button("Add next point")) {
                RoutePoint.CreateNextPoint();
            }
        }
    }
}