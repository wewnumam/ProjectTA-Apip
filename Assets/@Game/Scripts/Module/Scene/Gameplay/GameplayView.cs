using Agate.MVC.Base;
using ProjectTA.Module.CharacterDisplay;
using ProjectTA.Module.Dialogue;
using ProjectTA.Module.Settings;
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

        [field: SerializeField]
        public DialogueView DialogueView { get; private set; }
        [field: SerializeField]
        public CharacterDisplayView CharacterDisplayView { get; private set; }
        [field: SerializeField]
        public SettingsView SettingsView { get; private set; }

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
