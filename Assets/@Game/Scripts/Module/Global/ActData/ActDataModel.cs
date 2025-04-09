using Agate.MVC.Base;
using ProjectTA.Utility;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ProjectTA.Module.ActData
{
    public class ActDataModel : BaseModel, IActDataModel
    {
        public SOActData CurrentActData { get; private set; }
        public SOActCollection ActCollection { get; private set; }
        public SavedActData SavedActData { get; private set; } = new();

        public GameObject CurrentEnvironmentPrefab { get; private set; }

        public void SetCurrentActData(SOActData actData)
        {
            CurrentActData = actData;
            SavedActData.CurrentActName = actData.name;
        }

        public void SetActCollection(SOActCollection actCollection)
        {
            ActCollection = actCollection;
        }

        public void SetCurrentEnvironmentPrefab(GameObject currentEnvironmentPrefab)
        {
            CurrentEnvironmentPrefab = currentEnvironmentPrefab;
        }

        public void SetSavedActData(SavedActData unlockedActs)
        {
            SavedActData = unlockedActs;
        }

        public void AddUnlockedAct(string actName)
        {
            if (!SavedActData.UnlockedActs.Contains(actName))
            {
                SavedActData.UnlockedActs.Add(actName);
            }
            else
            {
                Debug.Log($"{actName} is already unlocked!");
            }
        }

        public List<SOActData> GetUnlockedActs()
        {
            List<SOActData> unlockedActs = new();
            unlockedActs.AddRange(from actData in ActCollection.ActItems
                                    where SavedActData.UnlockedActs.Contains(actData.name)
                                    select actData);
            return unlockedActs;
        }

        public bool IsMemberValid()
        {
            return Validator.ValidateNotNull(ActCollection, "LEVELCOLLECTION IS NULL") &&
                Validator.ValidateNotNull(CurrentActData, "CURRENTLEVELDATA IS NULL") &&
                Validator.ValidateCollection(GetUnlockedActs(), "UNLOCKEDLEVELS IS NULL");
        }
    }
}