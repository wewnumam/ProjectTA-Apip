using ProjectTA.Module.ActData;

namespace ProjectTA.Message
{
    public struct ChooseActMessage
    {
        public SOActData ActData { get; }

        public ChooseActMessage(SOActData levelData)
        {
            ActData = levelData;
        }
    }
}