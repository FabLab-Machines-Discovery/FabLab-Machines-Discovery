using System.Collections;
using UnityEngine;
using Utility;

namespace Onboarding_Scene
{
    public class OnboardingManager : MonoBehaviour
    {
        [Tooltip("First panel that appears")]
        public GameObject logoPanel;
        [Tooltip("Time to wait in seconds before switching from logo panel to start panel")]
        public float logoPanelDuration;
        [Tooltip("Second panel that appears")]
        public GameObject startPanel;
        [Tooltip("Third panel that appears")]
        public GameObject tutorialPanel;
        [Tooltip("Pagination for the tutorial panel")]
        public GameObject panelPagination;
        [Tooltip("Panel to show when loading the Vuforia scene")]
        public GameObject loadingPanel;

        private void OnValidate()
        {
            // Don't allow negative duration as it does not make sense
            logoPanelDuration = logoPanelDuration < 0 ? 0 : logoPanelDuration;
        }

        private void Start()
        {
            StartCoroutine(SwitchToStartPanel());
        }

        private IEnumerator SwitchToStartPanel()
        {
            // Wait for the duration then switch from logo panel to start panel
            yield return new WaitForSeconds(logoPanelDuration);
            logoPanel.SetActive(false);
        }

        public void SwitchToTutorialPanels()
        {
            // Switch from start panel to tutorial panel
            startPanel.SetActive(false);
            tutorialPanel.SetActive(true);
            panelPagination.SetActive(true);
        }

        public void LoadVuforiaScene()
        { 
            // This scene will always be the scene with index 0, hence loading the next scene is 1
            // Switch from tutorial panel to loading panel
            tutorialPanel.SetActive(false);
            panelPagination.SetActive(false);
            loadingPanel.SetActive(true);
            StartCoroutine(SceneLoader.LoadSceneAsync(1));
        }
    }
    
}