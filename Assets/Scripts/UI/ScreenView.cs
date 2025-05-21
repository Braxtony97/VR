using UnityEngine;

namespace UI
{
    public abstract class ScreenView : MonoBehaviour, IScreenView
    {
        [SerializeField] protected CanvasGroup _canvasGroup;
        
        public void Show()
        {
            if (_canvasGroup !=null) 
                _canvasGroup.alpha = 1;
        }

        public void Hide()
        {
            if (_canvasGroup !=null)
                _canvasGroup.alpha = 0;
        }
    }
}