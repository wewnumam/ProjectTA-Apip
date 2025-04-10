using Agate.MVC.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectTA.Module.CharacterDisplay
{
    public class CharacterDisplayModel : BaseModel, ICharacterDisplayModel
    {
        public List<CharacterComponent> Characters { get; private set; } = new List<CharacterComponent>();

        public bool IsCharacterExist(string characterName)
        {
            if (characterName == null)
                throw new ArgumentNullException(nameof(characterName));

            return Characters.Any(character => character.name == characterName);
        }
    }
}