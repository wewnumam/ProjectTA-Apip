using UnityEngine;
using UnityEngine.UI;

namespace ProjectTA.Module.CharacterDisplay
{
    public class CharacterComponent : MonoBehaviour
    {
        [field: SerializeField]
        public Image Image {  get; set; }

        public void Activate()
        {
            Color modifiedColor = Image.color;
            modifiedColor.a = 1f;
            Image.color = modifiedColor;
        }

        public void Deactivate()
        {
            Color modifiedColor = Image.color;
            modifiedColor.a = 0.5f;
            Image.color = modifiedColor;
        }
    }
}