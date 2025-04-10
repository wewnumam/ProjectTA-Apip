using Agate.MVC.Base;
using Agate.MVC.Core;
using ProjectTA.Boot;
using ProjectTA.Message;
using ProjectTA.Module.ActData;
using ProjectTA.Module.Dialogue;
using ProjectTA.Module.SaveSystem;
using ProjectTA.Utility;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectTA.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        public override string SceneName { get { return TagManager.SCENE_GAMEPLAY; } }

        private readonly GameSettingsController _gameSettings = new();
        private readonly ActDataController _actData = new();

        private readonly DialogueController _dialogue = new();

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {
                new DialogueController(),
            };
        }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[] {
                new DialogueConnector(),
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

            _view.SetCallbacks(OnMainMenu);

            _view.Title.SetText(_actData.Model.CurrentActData.Title);

            _dialogue.SetView(_view.DialogueView);

            Publish(new ShowDialogueMessage(_actData.Model.CurrentActData.TextAsset));

            yield return null;
        }

        private void OnMainMenu()
        {
            SceneLoader.Instance.LoadScene(TagManager.SCENE_MAINMENU);
        }
    }
}
