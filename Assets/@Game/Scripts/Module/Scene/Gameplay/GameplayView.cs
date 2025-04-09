using Agate.MVC.Base;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectTA.Scene.Gameplay
{
    public class GameplayView : BaseSceneView
    {
        private UnityAction _onMainMenu;
        
        [field: SerializeField]
        public TMP_Text Title {  get; set; }

        public void OnMainMenu()
        {
            _onMainMenu?.Invoke();
        }

        public void SetCallbacks(UnityAction onMainMenu)
        {
            _onMainMenu = onMainMenu;
        }
    }
}
