using UnityEngine;

namespace UI
{
    public abstract class ScreenView : MonoBehaviour, IScreenView
    {
        [Header("\nScreen type")]
        public Enums.ScreenType ScreenType;
        
        [Header("\nCanvas type")]
        public Enums.CanvasType CanvasType;
        
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