using System;
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
        [Tooltip("Script that plays the machine's simulation. It requires an Animator component attached to it")]
        public MachineSimulation simulation;

        /// <summary>
        /// Updates the UI of <see cref="PopupInfoUI"/> using this popup's information reference and type.
        /// If the popup type is "Simulation", it will also play the machine's simulation.
        /// </summary>
        public void ShowContents()
        {
            PopupInfoUI.Instance.UpdatePopupInfo(informationReference, type);
            
            if (type == PopupType.Simulation)
            {
                simulation.Play();
            }
        }
    }
}