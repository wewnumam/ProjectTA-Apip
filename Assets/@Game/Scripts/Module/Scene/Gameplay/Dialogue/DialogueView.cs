using Agate.MVC.Base;
using DG.Tweening;
using NaughtyAttributes;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjectTA.Module.Dialogue
{
    public class DialogueView : ObjectView<IDialogueModel>
    {
        [SerializeField] private TMP_Text _characterText;
        [SerializeField] private Text _messageText;
        [SerializeField] private List<GameObject> _choices;
        [SerializeField] private UnityEvent _onStart;
        [SerializeField] private UnityEvent _onEnd;
        [SerializeField] private UnityEvent _onLastLine;
        [SerializeField] private UnityEvent<bool> _isChoiceActive;
        [SerializeField, ResizableTextArea, ReadOnly] private string _log;

        private UnityAction _onNext;
        private Tween _tween;

        public UnityEvent OnStart => _onStart;
        public UnityEvent OnEnd => _onEnd;
        public UnityEvent OnLastLine => _onLastLine;

        public void DisplayNextLine()
        {
            _onNext?.Invoke();
            EventSystem.current.SetSelectedGameObject(null);
        }

        public void MakeChoice(int index)
        {
            _model.Story.ChooseChoiceIndex(index);
            EventSystem.current.SetSelectedGameObject(null);
            for (int i = 0; i < _choices.Count; i++)
            {
                _choices[i].SetActive(false);
            }
            DisplayNextLine();
        }

        public void SetCallback(UnityAction onNext)
        {
            this._onNext = onNext;
        }

        protected override void InitRenderModel(IDialogueModel model)
        {
            _log = model.GetLog();
        }

        protected override void UpdateRenderModel(IDialogueModel model)
        {
            _characterText.SetText(model.CharacterName);

            if (model.IsTextAnimationComplete)
            {
                _messageText.text = string.Empty;

                _tween = _messageText.DOText(model.Message, model.Message.Length / 20f).OnComplete(() => model.OnTextAnimationComplete?.Invoke());
            }
            else
            {
                _tween.Kill();
                _messageText.text = model.Message;
            }

            if (model.Story != null)
            {
                int index = 0;

                _isChoiceActive?.Invoke(model.Story.currentChoices.Count > 0);

                foreach (var choice in model.Story.currentChoices)
                {
                    _choices[index].SetActive(true);
                    _choices[index].GetComponentInChildren<TMP_Text>().SetText(choice.text);
                    index++;
                }

                for (int i = index; i < _choices.Count; i++)
                {
                    _choices[i].SetActive(false);
                }
            }

            _log = model.GetLog();
        }
    }
}