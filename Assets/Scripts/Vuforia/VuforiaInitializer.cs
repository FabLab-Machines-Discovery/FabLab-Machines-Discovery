using TMPro;
using UnityEngine;

namespace Vuforia
{
    public class VuforiaInitializer : MonoBehaviour
    {
        // Instance - Singleton pattern
        public static VuforiaInitializer Instance { get; private set; }

        [Tooltip("Panel initially shown when vuforia is still starting")]
        public GameObject loadingPanel;
        [Tooltip("Panel to show if a permission is missing")]
        public GameObject permissionErrorPanel;
        [Tooltip("Panel to show if an unknown error occured")]
        public GameObject unknownErrorPanel;
        [Tooltip("Text that would display the unknown error code")]
        public TextMeshProUGUI unknownErrorText;
        [Tooltip("GameObject that has all the Vuforia error handler components")]
        public GameObject vuforiaErrorHandlers;

        // Singleton pattern
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Initialize();
                Instance = this;
            }
        }

        // Unsubscribe from Vuforia events
        private void OnDestroy()
        {
            if (VuforiaApplication.Instance == null) return;
            
            VuforiaApplication.Instance.OnVuforiaInitialized -= HandleInitializationError;
            VuforiaApplication.Instance.OnVuforiaStarted -= DisableLoadingScreen;
        }

        // Subscribe to Vuforia events and initialize Vuforia's instance
        private void Initialize()
        {
            VuforiaApplication.Instance.OnVuforiaInitialized += HandleInitializationError;
            VuforiaApplication.Instance.OnVuforiaStarted += DisableLoadingScreen;
            VuforiaApplication.Instance.Initialize();
        }
        
        /*
         * If there is no error, simply destroy the GameObject that has the vuforia error handler components
         * Otherwise, display the respective error panel
         */
        private void HandleInitializationError(VuforiaInitError error)
        {
            switch (error)
            {
                case VuforiaInitError.NONE:
                    Destroy(vuforiaErrorHandlers);
                    break;
                case VuforiaInitError.PERMISSION_ERROR:
                    permissionErrorPanel.SetActive(true);
                    break;
                default:
                    unknownErrorPanel.SetActive(true);
                    unknownErrorText.text = "Code: " + error;
                    break;
            }
        }

        private void DisableLoadingScreen()
        {
            loadingPanel.SetActive(false);
        }
    }
}