using UnityEditor;
using Popups;

namespace Editor.Animations
{
    [CustomEditor(typeof(Popup))]
    public class PopupCustomEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            // Draw all properties except "simulation"
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject,"simulation");
            
            // Draw simulation if the popup type is "Simulation"
            var typeProp = serializedObject.FindProperty("type");
            var type = (PopupType)typeProp.enumValueIndex;
            if (type == PopupType.Simulation)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("simulation"));
            }
            
            // Apply modified properties
            serializedObject.ApplyModifiedProperties();
        }
    }
}