using System.Collections.Generic;
using UnityEngine;

namespace ProjectTA.Module.ActData
{
    [CreateAssetMenu(fileName = "ActCollection", menuName = "ProjectTA/ActCollection")]
    public class SOActCollection : ScriptableObject
    {

        [SerializeField] private List<SOActData> _actItems;

        public List<SOActData> ActItems
        {
            get { return _actItems; }
            set { _actItems = value; }
        }
    }
}
