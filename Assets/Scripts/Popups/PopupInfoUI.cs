using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Popups
{
    public class PopupInfoUI : MonoBehaviour
    {
        public static PopupInfoUI Instance { get; private set; }

        public Image border;
        public TextMeshProUGUI text;
        
        private LocalizedString _information;
        [SerializeField] private string stringTableReference;
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                _information = new LocalizedString();
                Instance = this;
            }
        }

        public void DisplayPopupInfo(string reference, PopupType type)
        {
            _information.TableReference = stringTableReference;
            _information.TableEntryReference = reference;
            text.text = _information.GetLocalizedString();
            Debug.Log(type);
        }
    }
}