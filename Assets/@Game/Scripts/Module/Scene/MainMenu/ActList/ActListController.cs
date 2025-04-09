using Agate.MVC.Base;
using ProjectTA.Module.ActData;
using ProjectTA.Module.ActItem;
using UnityEngine;

namespace ProjectTA.Module.ActList
{
    public class ActListController : ObjectController<ActListController, ActDataModel, ActListView>
    {
        public void SetModel(ActDataModel model)
        {
            _model = model;
        }

        public void InitModel(IActDataModel collectibleData)
        {
            if (collectibleData == null)
            {
                Debug.LogError("COLLECTIBLEDATA IS NULL");
                return;
            }
            if (collectibleData.ActCollection == null)
            {
                Debug.LogError("COLLECTIBLECOLLECTION IS NULL");
                return;
            }

            _model.SetActCollection(collectibleData.ActCollection);
            _model.SetSavedActData(collectibleData.SavedActData);
        }

        public override void SetView(ActListView view)
        {
            base.SetView(view);

            foreach (var collectibleItem in _model.ActCollection.ActItems)
            {
                GameObject obj = GameObject.Instantiate(view.ItemTemplate.gameObject, view.Parent);

                ActItemView collectibleItemView = obj.GetComponent<ActItemView>();
                ActItemController collectibleItemController = new ActItemController();
                InjectDependencies(collectibleItemController);
                collectibleItemController.Init(collectibleItemView, collectibleItem, _model.SavedActData.UnlockedActs.Contains(collectibleItem.name));

                obj.SetActive(true);
            }
        }
    }
}