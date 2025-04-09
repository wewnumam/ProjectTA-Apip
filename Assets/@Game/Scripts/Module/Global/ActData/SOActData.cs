using NaughtyAttributes;
using UnityEngine;

namespace ProjectTA.Module.ActData
{
    [CreateAssetMenu(fileName = "ActData_", menuName = "ProjectTA/ActData")]
    public class SOActData : ScriptableObject
    {
        [field: SerializeField]
        public string Title { get; private set; }
        [field: SerializeField, ResizableTextArea]
        public string Description { get; private set; }
        [field: SerializeField]
        public bool IsLockedAct { get; private set; }
    }
}
