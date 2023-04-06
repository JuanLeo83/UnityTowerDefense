using Components.Router.Scripts;
using UnityEditor;
using UnityEngine;

namespace Components.Router.RouterEditor {
    [CustomEditor(typeof(RouteCreator)), CanEditMultipleObjects]
    public class RouteCreatorEditor : Editor {
        private RouteCreator RouteCreator => target as RouteCreator;

        private void OnSceneGUI() {
            EditorGUI.BeginChangeCheck();

            foreach (var point in RouteCreator.getPoints()) {
                var textStyle = new GUIStyle {
                    fontStyle = FontStyle.Bold,
                    fontSize = 18,
                    normal = {textColor = Color.cyan}
                };

                var textAlign = Vector3.down * 0.3f + Vector3.left * 0.1f;
                Handles.Label(
                    point.transform.position + textAlign,
                    point.position.ToString(),
                    textStyle
                );
            }

            EditorGUI.EndChangeCheck();
        }

        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            if (GUILayout.Button("Add point")) {
                RouteCreator.createNextPoint();
            }
        }
    }
}