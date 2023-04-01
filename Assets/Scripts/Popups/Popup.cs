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
        
        /// <summary>
        /// Updates the UI of <see cref="PopupInfoUI"/> using this popup's information reference and type
        /// </summary>
        public void SetPopupInfo()
        {
            PopupInfoUI.Instance.UpdatePopupInfo(informationReference, type);
        }
    }
}