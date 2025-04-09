using ProjectTA.Module.ActData;

namespace ProjectTA.Message
{
    public struct UnlockActMessage
    {
        public SOActData ActData { get; }

        public UnlockActMessage(SOActData levelData)
        {
            ActData = levelData;
        }
    }
}