using ProjectTA.Utility;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectTA.Module.ActData
{
    [Serializable]
    public class SavedActData
    {
        [field: SerializeField]
        public string CurrentActName { get; set; } = TagManager.DEFAULT_LEVELNAME;
        [field: SerializeField]
        public List<string> UnlockedActs { get; set; } = new();
    }
}