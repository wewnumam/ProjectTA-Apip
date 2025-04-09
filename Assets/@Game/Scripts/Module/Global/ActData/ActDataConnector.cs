using Agate.MVC.Base;
using ProjectTA.Message;

namespace ProjectTA.Module.ActData
{
    public class ActDataConnector : BaseConnector
    {
        private readonly ActDataController _levelData = new();

        protected override void Connect()
        {
            Subscribe<ChooseActMessage>(_levelData.OnChooseAct);
            Subscribe<UnlockActMessage>(_levelData.OnUnlockAct);
            Subscribe<DeleteSaveDataMessage>(_levelData.OnDeleteSaveData);
        }

        protected override void Disconnect()
        {
            Unsubscribe<ChooseActMessage>(_levelData.OnChooseAct);
            Unsubscribe<UnlockActMessage>(_levelData.OnUnlockAct);
            Unsubscribe<DeleteSaveDataMessage>(_levelData.OnDeleteSaveData);
        }
    }
}