using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ProjectTA.Module.CharacterDisplay
{
    public class CharacterComponent : MonoBehaviour
    {
        [field: SerializeField]
        public Image Image {  get; set; }
        [field: SerializeField]
        public UnityEvent<bool> IsActive {  get; private set; }

        public void Activate()
        {
            Color modifiedColor = Image.color;
            modifiedColor.a = 1f;
            Image.color = modifiedColor;
            IsActive.Invoke(true);
        }

        public void Deactivate()
        {
            Color modifiedColor = Image.color;
            modifiedColor.a = 0.5f;
            Image.color = modifiedColor;
            IsActive.Invoke(false);
        }
    }
}