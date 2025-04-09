using Agate.MVC.Base;
using ProjectTA.Message;
using ProjectTA.Utility;
using System;
using System.Collections;
using UnityEngine;

namespace ProjectTA.Module.ActData
{
    public class ActDataController : DataController<ActDataController, ActDataModel, IActDataModel>
    {
        #region UTILITY

        private ISaveSystem<SavedActData> _savedActData = null;
        private IResourceLoader _resourceLoader = null;

        public void SetSaveSystem(ISaveSystem<SavedActData> savedActData)
        {
            _savedActData = savedActData;
        }

        public void SetResourceLoader(IResourceLoader resourceLoader)
        {
            _resourceLoader = resourceLoader;
        }

        public void SetModel(ActDataModel model)
        {
            _model = model;
        }

        #endregion

        public override IEnumerator Initialize()
        {
            if (_resourceLoader == null)
            {
                _resourceLoader = new ResourceLoader();
            }

            if (_savedActData == null)
            {
                _savedActData = new SaveSystem<SavedActData>(TagManager.FILENAME_SAVEDACTDATA);
            }
            _model.SetSavedActData(_savedActData.Load());

            SetCurrentAct(_model.SavedActData.CurrentActName);

            LoadActCollection();

            InitUnlockedAct();

            yield return base.Initialize();
        }

        #region PRIVATE METHOD

        private void LoadActCollection()
        {
            SOActCollection actCollection = _resourceLoader.Load<SOActCollection>(TagManager.SO_ACTCOLLECTION);
            if (actCollection != null)
            {
                _model.SetActCollection(actCollection);
            }
            else
            {
                Debug.LogError($"ACT COLLECTION SCRIPTABLE NOT FOUND!");
            }
        }

        private void InitUnlockedAct()
        {
            if (_model.ActCollection == null ||
                _model.ActCollection.ActItems == null ||
                _model.ActCollection.ActItems.Count <= 0)
            {
                return;
            }

            foreach (var levelItem in _model.ActCollection.ActItems)
            {
                if (!levelItem.IsLockedAct)
                {
                    OnUnlockAct(new UnlockActMessage(levelItem));
                }
            }
        }

        private void SetCurrentAct(string levelName)
        {
            SOActData actData = _resourceLoader.Load<SOActData>(@"ActData/" + levelName);
            if (actData != null)
            {
                _model.SetCurrentActData(actData);
            }
            else
            {
                Debug.LogError($"{levelName} SCRIPTABLE NOT FOUND!");
            }
        }

        #endregion

        #region MESSAGE LISTENER

        public void OnChooseAct(ChooseActMessage message)
        {
            SetCurrentAct(message.ActData.name);
            _savedActData.Save(_model.SavedActData);
            Debug.Log($"CHOOSE ACT: {message.ActData}");
        }

        public void OnUnlockAct(UnlockActMessage message)
        {
            if (message.ActData != null)
            {
                _model.AddUnlockedAct(message.ActData.name);
                _savedActData.Save(_model.SavedActData);
            }
            else
            {
                Debug.LogWarning($"ACT DATA MESSAGE IS NULL!");
            }
        }

        public void OnDeleteSaveData(DeleteSaveDataMessage message)
        {
            _savedActData.Delete();
        }

        #endregion
    }
}
