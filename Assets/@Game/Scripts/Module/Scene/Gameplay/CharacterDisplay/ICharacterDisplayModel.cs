using Agate.MVC.Base;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTA.Module.CharacterDisplay
{
    public interface ICharacterDisplayModel : IBaseModel
    {
        List<CharacterComponent> Characters { get; }
    }
}