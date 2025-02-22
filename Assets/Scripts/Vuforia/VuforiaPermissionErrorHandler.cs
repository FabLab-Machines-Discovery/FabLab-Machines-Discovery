using System.Collections;
using UnityEngine;
using UnityEngine.Android;

namespace Vuforia
{
    public class VuforiaPermissionErrorHandler : MonoBehaviour, IVuforiaErrorHandler
    {
        [Tooltip("Panel to show if a permission is missing")]
        public GameObject permissionErrorPanel;
        
        /// <summary>
        /// Requests the user to grant access to the missing permissions.
        /// Once the permissions are granted, it will initialize Vuforia again.
        /// </summary>
        public void HandleError()
        {
#if UNITY_ANDROID
            HandlePermission();
#elif UNITY_IOS
            StartCoroutine(HandlePermission());
#endif
        }

#if UNITY_ANDROID
        // Android Specific
        private void HandlePermission()
        {
            // Call Continue() from a callback if permissions are granted
            var callbacks = new PermissionCallbacks();
            callbacks.PermissionGranted += (s) => { StartCoroutine(Continue()); };
            
            // Request missing permissions
            Permission.RequestUserPermission(Permission.Camera, callbacks);
        }
#elif UNITY_IOS
        // iOS Specific
        private IEnumerator HandlePermission()
        {
            // Wait for the user grant or deny permissions
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            
            // Only call Continue() if permissions were granted
            if (Application.HasUserAuthorization(UserAuthorization.WebCam))
            {
                StartCoroutine(Continue());
            }
        }
#endif
        
        // Called after user grants the missing permission
        private IEnumerator Continue()
        {
            // Hide the permission error panel, then wait for a few frames for the canvas renderer to update
            permissionErrorPanel.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            
            // Initialize Vuforia now that the loading panel is visible instead of the permission error panel
            VuforiaApplication.Instance.Initialize();
        }
    }
}