using Agate.MVC.Base;
using System.Collections.Generic;

namespace ProjectTA.Module.ActData
{
    public interface IActDataModel : IBaseModel
    {
        SOActData CurrentActData { get; }
        SOActCollection ActCollection { get; }
        SavedActData SavedActData { get; }

        List<SOActData> GetUnlockedActs();

        bool IsMemberValid();
    }
}