using Agate.MVC.Base;
using ProjectTA.Module.ActList;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectTA.Scene.MainMenu
{
    public class MainMenuView : BaseSceneView
    {
        private UnityAction _onPlay, _onQuit;

        [field: SerializeField]
        public ActListView ActListView { get; private set; }

        public void Play()
        {
            _onPlay.Invoke();
        }

        public void Quit()
        {
            _onQuit?.Invoke();
        }

        public void SetCallbacks(UnityAction onPlay, UnityAction onQuit)
        {
            _onPlay = onPlay;
            _onQuit = onQuit;
        }
    }
}
