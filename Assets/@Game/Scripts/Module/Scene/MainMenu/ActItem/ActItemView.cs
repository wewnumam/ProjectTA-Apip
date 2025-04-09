using Agate.MVC.Base;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectTA.Module.ActItem
{
    public class ActItemView : BaseView
    {
        [field: SerializeField]
        public TMP_Text Title { get; set; }
        [field: SerializeField]
        public TMP_Text Description { get; set; }

        [field: SerializeField]
        public Button ChooseButton { get; set; }

        public void SetCallback(UnityAction onChooseCollectible)
        {
            ChooseButton.onClick.RemoveAllListeners();
            ChooseButton.onClick.AddListener(onChooseCollectible);
        }
    }
}