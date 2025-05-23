using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class MainMenuScreen : ScreenView
    {
        [Header("\nUI Elements")]
        [SerializeField] private Button _trainingScene;
        [SerializeField] private Button _exitButton;
        public override void Initialize()
        {
            //_trainingScene.onClick.AddListener() => _sceneLoader;
        }

        public override void Deinitialize()
        {
        }
    }
}