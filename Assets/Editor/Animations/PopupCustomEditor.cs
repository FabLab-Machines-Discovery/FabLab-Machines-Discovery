using UnityEditor;
using Popups;


namespace Editor.Animations
{
    [CustomEditor(typeof(Popup))]
    public class PopUp : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            DrawPropertiesExcluding(serializedObject,"simulation");
            var typeProp = serializedObject.FindProperty("type");
            var type = (PopupType)typeProp.enumValueIndex;

            if (type == PopupType.Simulation)
            {
                EditorGUILayout.PropertyField(serializedObject.FindProperty("simulation"));
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}