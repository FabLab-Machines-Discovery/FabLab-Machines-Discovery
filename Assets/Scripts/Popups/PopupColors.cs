using System;
using UnityEngine;

namespace Popups
{
    [Serializable] public class PopupColors
    {
        [SerializeField] private Color generalColor;
        [SerializeField] private Color useInstructionColor;
        [SerializeField] private Color technicalColor;
        [SerializeField] private Color safetyRiskColor;
        [SerializeField] private Color simulationColor;
        [SerializeField] private Color defaultColor;

        public Color DefaultColor => defaultColor;

        // Get a color depending on type of popup
        public Color GetColor(PopupType type)
        {
            switch (type)
            {
                case PopupType.General:
                    return generalColor;
                case PopupType.UseInstruction:
                    return useInstructionColor;
                case PopupType.Technical:
                    return technicalColor;
                case PopupType.SafetyRisk:
                    return safetyRiskColor;
                case PopupType.Simulation:
                    return simulationColor;
                default:
                    return defaultColor;
            }
        }
    }

}