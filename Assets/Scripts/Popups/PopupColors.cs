using System;
using UnityEngine;

namespace Popups
{
    [Serializable] public class PopupColors
    {
        public Color generalColor;
        public Color useInstructionColor;
        public Color technicalColor;
        public Color safetyRiskColor;
        public Color defaultColor;

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
                default:
                    return defaultColor;
            }
        }
    }

}