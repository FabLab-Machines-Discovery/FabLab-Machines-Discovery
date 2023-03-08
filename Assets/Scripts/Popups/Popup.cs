using System;
using UnityEngine;

namespace Popups
{
    public enum PopupType
    {
        General, UseInstruction, Technical, SafetyRisk
    }
    public class Popup : MonoBehaviour
    {
        public string reference;
        public PopupType type;

        public void SetPopupInfo()
        {
            PopupInfoUI.Instance.DisplayPopupInfo(reference, type);
        }
    }
}