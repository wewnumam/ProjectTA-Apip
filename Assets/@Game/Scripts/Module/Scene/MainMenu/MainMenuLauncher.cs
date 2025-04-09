using Agate.MVC.Base;
using Agate.MVC.Core;
using ProjectTA.Boot;
using ProjectTA.Message;
using ProjectTA.Module.ActData;
using ProjectTA.Module.ActList;
using ProjectTA.Module.SaveSystem;
using ProjectTA.Utility;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectTA.Scene.MainMenu
{
    public class MainMenuLauncher : SceneLauncher<MainMenuLauncher, MainMenuView>
    {
        public override string SceneName { get { return TagManager.SCENE_MAINMENU; } }

        private readonly GameSettingsController _gameSettings = new();
        private readonly ActDataController _actData = new();

        private readonly ActListController _actList = new();

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {
                new ActListController(),
            };
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[] {
            };
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }

        protected override IEnumerator InitSceneObject()
        {
            Time.timeScale = 1;

            Publish(new GameStateMessage(EnumManager.GameState.PreGame));

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(SceneName));

            PlayerPrefs.SetString(TagManager.KEY_VERSION, Application.version);

            _view.SetCallbacks(OnPlay, OnQuit);

            _actList.InitModel(_actData.Model);
            _actList.SetView(_view.ActListView);

            yield return null;
        }

        private void OnPlay()
        {
            SceneLoader.Instance.LoadScene(TagManager.SCENE_GAMEPLAY);
        }

        private void OnQuit()
        {
            Application.Quit();
        }
    }
}
