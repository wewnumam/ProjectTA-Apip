using Agate.MVC.Base;
using ProjectTA.Module.ActItem;
using TMPro;
using UnityEngine;

namespace ProjectTA.Module.ActList
{
    public class ActListView : BaseView
    {
        [field: SerializeField]
        public Transform Parent { get; set; }
        [field: SerializeField]
        public ActItemView ItemTemplate { get; set; }
    }
}