using Agate.MVC.Base;
using Agate.MVC.Core;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace ProjectTA.Boot
{
    public class SplashScreen : BaseSplash<SplashScreen>
    {
        [SerializeField] TMP_Text versionText;
        [SerializeField] UnityEvent<bool> isStartTransition;

        protected override IMain GetMain()
        {
            return GameMain.Instance;
        }

        protected override ILoad GetLoader()
        {
            return SceneLoader.Instance;
        }

        protected override void StartSplash()
        {
            base.StartSplash();
            versionText.SetText($"v{Application.version}");
        }

        protected override void StartTransition()
        {
            base.StartTransition();
            isStartTransition?.Invoke(true);
        }

        protected override void FinishTransition()
        {
            base.FinishTransition();
            isStartTransition?.Invoke(false);
        }
    }
}
