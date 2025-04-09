using Agate.MVC.Base;
using ProjectTA.Message;
using ProjectTA.Module.ActData;

namespace ProjectTA.Module.ActItem
{
    public class ActItemController : ObjectController<ActItemController, ActItemView>
    {
        private SOActData _collectibleData = null;

        public void Init(ActItemView view, SOActData collectibleData, bool isUnlocked)
        {
            SetView(view);
            _collectibleData = collectibleData;
            view.Title.SetText(collectibleData.Title);
            view.Description.SetText(collectibleData.Description);
            view.ChooseButton.interactable = isUnlocked;
        }

        public override void SetView(ActItemView view)
        {
            base.SetView(view);
            view.SetCallback(OnChooseCollectible);
        }

        private void OnChooseCollectible()
        {
            Publish(new ChooseActMessage(_collectibleData));
        }
    }
}