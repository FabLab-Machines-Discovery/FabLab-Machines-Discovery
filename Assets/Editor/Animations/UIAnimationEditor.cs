using Animations;
using UnityEditor;
using UnityEngine;
// ReSharper disable All

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
                
                uiAnimationScript.ResetObj();
                uiAnimationScript.PlayAnimation();
            }
        }
    }
}