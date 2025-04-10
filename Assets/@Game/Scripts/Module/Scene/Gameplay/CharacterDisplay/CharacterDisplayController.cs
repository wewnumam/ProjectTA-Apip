using Agate.MVC.Base;
using ProjectTA.Message;
using ProjectTA.Module.ActData;
using ProjectTA.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTA.Module.CharacterDisplay
{
    public class CharacterDisplayController : ObjectController<CharacterDisplayController, CharacterDisplayModel, ICharacterDisplayModel, CharacterDisplayView>
    {
        private IResourceLoader _resourceLoader = null;

        public override IEnumerator Initialize()
        {
            if (_resourceLoader == null)
            {
                _resourceLoader = new ResourceLoader();
            }

            yield return base.Initialize();
        }

        private CharacterComponent LoadCharacter(string characterName)
        {
            CharacterComponent character = _resourceLoader.Load<CharacterComponent>(@"Characters/" + characterName);
            
            if (character == null)
            {
                Debug.LogError($"{characterName} PREFAB NOT FOUND!");
            }

            return character;
        }

        public void InitCharacter(List<CharacterComponent> characterComponents)
        {
            foreach (var character in characterComponents)
            {
                SpawnCharacter(character);
            }
        }

        public void SpawnCharacter(CharacterComponent characterComponent)
        {
            GameObject obj = GameObject.Instantiate(characterComponent.gameObject, _view.gameObject.transform);
            obj.name = characterComponent.name;
            _model.Characters.Add(obj.GetComponent<CharacterComponent>());
        }

        public void ActivateCharacter(ActivateCharacterMessage message)
        {
            if (!_model.IsCharacterExist(message.CharacterName))
            {
                var character = LoadCharacter(message.CharacterName);
                SpawnCharacter(character);
            }

            foreach (var character in _model.Characters)
            {
                if (character.name == message.CharacterName)
                {
                    character.Activate();
                }
                else
                {
                    character.Deactivate();
                }
            }
        }

        public void DeactivateCharacters(DeactivateCharactersMessage message)
        {
            foreach (var character in _model.Characters)
            {
                character.Deactivate();
            }
        }
    }
}
