using UnityEngine;

namespace Popups
{
    public enum PopupType
    {
        General, UseInstruction, Technical, SafetyRisk
    }
    public class Popup : MonoBehaviour
    {
        [Tooltip("Reference to the localized string that stores this popup's information")]
        public string reference = "Missing Reference";
        [Tooltip("Type of the popup")]
        public PopupType type;
        
        public void SetPopupInfo()
        {
            PopupInfoUI.Instance.DisplayPopupInfo(reference, type);
        }
    }
}