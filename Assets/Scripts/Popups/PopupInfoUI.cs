using Animations;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace Popups
{
    public class PopupInfoUI : MonoBehaviour
    {
        // Instance for Singleton pattern
        public static PopupInfoUI Instance { get; private set; }

        [SerializeField] [Tooltip("Duration of the enter/exit translation animation")]
        [Range(0, 1)] private float animationDuration;

        [SerializeField] [Tooltip("Container of the title text")]
        private Image titleContainer;

        [SerializeField] [Tooltip("Title text component")]
        private TextMeshProUGUI machineTitle;
        
        [SerializeField] [Tooltip("Information text component")]
        private TextMeshProUGUI information;
        
        [SerializeField] [Tooltip("Colors applied to text component and title container when a popup is clicked")]
        private PopupColors popupColors;

        [SerializeField] [Tooltip("Name of the localized string table")]
        private string stringTableReference = "Missing Table Reference";
        
        [SerializeField] [Tooltip("Reference to the localized string that holds the default information text")]
        private string defaultInformationReference = "Missing Default Reference";
        
        // Used to retrieve the localized popup information using its reference. Example: R3N1 G1
        private LocalizedString _localizedInformation;

        // Used to retrieve the localized machine title using its reference. Example: 3D Printer
        private LocalizedString _localizedMachineTitle;

        // Animation played when showing UI
        private TranslationAnimation _enterAnimation;
        
        // Animation played when hiding UI
        private TranslationAnimation _exitAnimation;
        
        // Singleton Pattern
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Initialize();
                Instance = this;
            }
        }

        // Called to initialize some members of this class on Awake
        private void Initialize()
        {
            _localizedInformation = new LocalizedString();
            _localizedMachineTitle = new LocalizedString();
            
            var localPositionY = transform.localPosition.y;
            var heightOfUI = GetComponent<RectTransform>().rect.height;
            // Enter animation: translate upwards from initial local position until whole UI is visible
            _enterAnimation = CreateTranslationAnimation(new Vector3(0, localPositionY + heightOfUI, 0));
            // Exit animation: translate back to initial local position
            _exitAnimation = CreateTranslationAnimation(new Vector3(0, localPositionY, 0));
        }

        // Called to create the components needed for enter and exit animations
        private TranslationAnimation CreateTranslationAnimation(Vector3 desiredPosition)
        {
            var translationAnimation = gameObject.AddComponent<TranslationAnimation>();

            // Initialize component members
            translationAnimation.animationProps = new UIAnimationProps<Vector3>
            {
                autoPlay = false,
                desiredValue = desiredPosition,
                duration = animationDuration,
                delay = 0
            };
            translationAnimation.isRelative = false;
            
            return translationAnimation;
        }

        // Update the title text component using reference to a localized string
        private void UpdateTitle(string reference)
        {
            _localizedMachineTitle.TableReference = stringTableReference;
            _localizedMachineTitle.TableEntryReference = reference;
            
            machineTitle.text = _localizedMachineTitle.GetLocalizedString();
        }
        
        // Update the information text component to the default
        private void UpdateInformationText()
        {
            _localizedInformation.TableReference = stringTableReference;
            _localizedInformation.TableEntryReference = defaultInformationReference;
            
            information.text = _localizedInformation.GetLocalizedString();
        }

        // Update the information text component using reference to a localized string
        private void UpdateInformationText(string reference)
        {
            _localizedInformation.TableReference = stringTableReference;
            _localizedInformation.TableEntryReference = reference;
            
            information.text = _localizedInformation.GetLocalizedString();
        }

        // Update the colors of the text and title component
        private void UpdateColor(Color color)
        {
            titleContainer.color = color;
            information.color = color;
        }

        /// <summary>
        /// Updates the displayed information and the color of the UI using the popup's information reference and type.
        /// </summary>
        /// <param name="informationReference">Reference to the localized string that holds the information</param>
        /// <param name="type">Type of the popup</param>
        public void UpdatePopupInfo(string informationReference, PopupType type)
        {
            UpdateInformationText(informationReference);
            UpdateColor(popupColors.GetColor(type));
        }
        
        /// <summary>
        /// Shows the UI by playing an enter animation and setting the machine title using the given reference.
        /// </summary>
        /// <param name="titleReference">Reference to the localized string that holds the machine title</param>
        public void ShowUI(string titleReference)
        {
            UpdateTitle(titleReference);
            
            // Set information text and color to default
            UpdateInformationText();
            UpdateColor(popupColors.defaultColor);
            
            _enterAnimation.Play();
        }

        /// <summary>
        /// Hides the UI by playing an exit animation.
        /// This will ONLY execute if the given reference matches the currently displayed machine title reference
        /// </summary>
        /// <param name="titleReference">Reference to the localized string that holds the machine title</param>
        public void HideUI(string titleReference)
        {
            if (titleReference != _localizedMachineTitle.TableEntryReference) return;
            
            _exitAnimation.Play();
        }
    }
}