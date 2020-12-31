using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Managers
{
    public class CutSceneManager : MonoBehaviour
    {
        [SerializeField] private GameObject topParagraphGO, centerParagraphGO, bottomParagraphGO;

        private int _stepCount;
        private ParagraphData _topParagraphData, _centerParagraphData, _bottomParagraphData;
        private bool _isAnimating;

        private void Awake()
        {
            _topParagraphData = topParagraphGO.GetComponent<ParagraphData>();
            _centerParagraphData = centerParagraphGO.GetComponent<ParagraphData>();
            _bottomParagraphData = bottomParagraphGO.GetComponent<ParagraphData>();

            _topParagraphData.OnAnimationEnd += OnAnimationEnd;
            _centerParagraphData.OnAnimationEnd += OnAnimationEnd;
            _bottomParagraphData.OnAnimationEnd += OnAnimationEnd;
        }

        private void Start()
        {
            InputManager.Instance.Cutscene.Enable();
            InputManager.Instance.Cutscene.Step.performed += OnStepInput;
            InputManager.Instance.Cutscene.Skip.performed += OnSkipInput;
        }

        private void OnDestroy()
        {
            InputManager.Instance.Cutscene.Disable();
        }

        private void OnStepInput(InputAction.CallbackContext obj)
        {
            if (_stepCount == 0)
            {
                if (_isAnimating)
                {
                    _topParagraphData.CompleteAnimation();
                    return;
                }
                _topParagraphData.StartAnimating();
                _isAnimating = true;
            } else if (_stepCount == 1)
            {
                if (_isAnimating)
                {
                    _centerParagraphData.CompleteAnimation();
                    return;
                }
                _centerParagraphData.StartAnimating();
                _isAnimating = true;
            } else if (_stepCount == 2)
            {
                if (_isAnimating)
                {
                    _bottomParagraphData.CompleteAnimation();
                    return;
                }
                _bottomParagraphData.StartAnimating();
                _isAnimating = true;
            }
            else
            {
                ApplicationManager.Instance.LoadScene(GameScene.MainMenu);
            }
        }

        private void OnSkipInput(InputAction.CallbackContext obj)
        {
            ApplicationManager.Instance.LoadScene(GameScene.MainMenu);
        }

        private void OnAnimationEnd()
        {
            _stepCount += 1;
            _isAnimating = false;
        }
    }
}