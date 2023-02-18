using System.Collections;
using UnityEngine;

namespace Onboarding_Scene
{
    public class PanelManager : MonoBehaviour
    {
        public GameObject logoPanel;
        [Tooltip("Time to wait in seconds before switching from logo panel to start panel")]
        public float logoPanelDuration;
        public GameObject startPanel;
        public GameObject tutorialPanel;

        private void OnValidate()
        {
            logoPanelDuration = logoPanelDuration < 0 ? 0 : logoPanelDuration;
        }

        private void Start()
        {
            StartCoroutine(SwitchToStartPanel());
        }

        IEnumerator SwitchToStartPanel()
        {
            yield return new WaitForSeconds(logoPanelDuration);
            logoPanel.SetActive(false);
            startPanel.SetActive(true);
        }

        public void SwitchToTutorialPanels()
        {
            startPanel.SetActive(false);
            tutorialPanel.SetActive(true);
        }
    }
    
}