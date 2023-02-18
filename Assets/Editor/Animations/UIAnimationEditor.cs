using Animations;
using UnityEditor;
using UnityEngine;

namespace Editor.Animations
{
    [CustomEditor(typeof(UIAnimation<>), true)]
    public class UIAnimationEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            var uiAnimationScript = target as IUIAnimation;

            EditorGUILayout.Space();
            
            if (GUILayout.Button("Play Animation"))
            {
                if (uiAnimationScript == null) return;

                if (!Application.isPlaying)
                {
                    Debug.LogWarning("You should be in play mode to play the animation");
                    return;
                }
                
                uiAnimationScript.PlayAnimation();
            }
            
            EditorGUILayout.Space();
            
            if (GUILayout.Button("Reset Object"))
            {
                if (uiAnimationScript == null) return;

                if (!Application.isPlaying)
                {
                    Debug.LogWarning("You should be in play mode to reset the animation");
                    return;
                }
                
                uiAnimationScript.ResetObj();
            }
        }
    }
}