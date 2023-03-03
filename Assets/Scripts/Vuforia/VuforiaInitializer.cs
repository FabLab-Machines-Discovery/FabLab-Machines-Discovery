using System;
using UnityEngine;

namespace Vuforia
{
    [DefaultExecutionOrder(-1)]
    public class VuforiaInitializer : MonoBehaviour
    {
        private void Awake()
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            VuforiaApplication.Instance.Initialize();
        }
    }
}