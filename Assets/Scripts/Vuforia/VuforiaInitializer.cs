using System;
using UnityEngine;

namespace Vuforia
{
    [DefaultExecutionOrder(-1)]
    public class VuforiaInitializer : MonoBehaviour
    {
        public GameObject loadingPanel;
        private void Awake()
        {
            VuforiaApplication.Instance.Initialize();
            VuforiaApplication.Instance.OnVuforiaStarted += DisableLoadingScreen;
        }

        private void OnDisable()
        {
            VuforiaApplication.Instance.OnVuforiaStarted -= DisableLoadingScreen;
        }

        private void DisableLoadingScreen()
        {
            loadingPanel.SetActive(false);
        }
    }
}