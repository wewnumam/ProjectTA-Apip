using UnityEngine;

namespace ProjectTA.Module.CharacterDisplay
{
    [CreateAssetMenu(fileName = "CharacterData_", menuName = "ProjectTA/CharacterData")]
    public class SOCharacterData : ScriptableObject
    {
        [field: SerializeField]
        public CharacterComponent CharacterComponent { get; set; }
    }
}
