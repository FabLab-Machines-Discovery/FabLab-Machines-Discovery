using UnityEngine;

namespace Popups
{
    public enum PopupType
    {
        General, UseInstruction, Technical, SafetyRisk, Simulation
    }
    public class Popup : MonoBehaviour
    {
        [Tooltip("Reference to the localized string that holds this popup's information")]
        public string informationReference = "Missing Reference";
        [Tooltip("Type of the popup")]
        public PopupType type;
        [Tooltip("GameObject that plays the machine's simulation. It requires an Animator component attached to it")]
        public GameObject simulationObject;
        
        private Animator _animator;

        /// <summary>
        /// Updates the UI of <see cref="PopupInfoUI"/> using this popup's information reference and type
        /// </summary>
        public void SetPopupInfo()
        {
            if (!simulationObject.activeSelf) // Check if the GameObject is inactive
            {
                simulationObject.SetActive(true);
            }

            PopupInfoUI.Instance.UpdatePopupInfo(informationReference, type);
        }

        public void OnValidate()
        {
            if(simulationObject == null) return;
            _animator = simulationObject.GetComponent<Animator>();
            if (_animator != null) return;
            simulationObject = null;
            Debug.LogWarning("Your gameObject doesn't contain an Animator component");
        }
    }
}