using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class ParagraphData : MonoBehaviour
    {
        [SerializeField] private ParagraphDataSO _data;
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _text;

        private Coroutine _fadeInImageCoroutine, _showLettersCoroutine;
        private bool _completedAnimation;

        public event Action OnAnimationEnd;
        
        private void Awake() => _image.sprite = _data.image;

        private IEnumerator FadeInImageOverTime()
        {
            for (var i = 0; i <= 100; i++)
            {
                SetImageAlpha(i * 0.01f);
                yield return new WaitForSeconds(0.01f);
            }
            
            if (_completedAnimation) OnAnimationEnd?.Invoke();
            else _completedAnimation = true;
        }

        private void SetImageAlpha(float alphaNormalized)
        {
            var originalColor = _image.color;
            _image.color = new Color(originalColor.r, originalColor.g, originalColor.b, alphaNormalized);
        }

        private IEnumerator ShowLettersOverTime()
        {
            var characters = _data.text.ToCharArray();
            foreach (var c in characters)
            {
                _text.text += c;
                yield return new WaitForSeconds(0.02f);
            }

            if (_completedAnimation) OnAnimationEnd?.Invoke();
            else _completedAnimation = true;
        }
        
        private void ShowAllText()
        {
            _text.text = _data.text;
        }

        public void StartAnimating()
        {
            _fadeInImageCoroutine = StartCoroutine(FadeInImageOverTime());
            _showLettersCoroutine = StartCoroutine(ShowLettersOverTime());
        }

        public void CompleteAnimation()
        {
            if (_fadeInImageCoroutine != null)
            {
                StopCoroutine(_fadeInImageCoroutine);
                _fadeInImageCoroutine = null;
            }

            if (_showLettersCoroutine != null)
            {
                StopCoroutine(_showLettersCoroutine);
                _showLettersCoroutine = null;
            }
            
            SetImageAlpha(1f);
            ShowAllText();
            
            OnAnimationEnd?.Invoke();
        }
    }
}