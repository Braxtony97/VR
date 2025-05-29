using Quests;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.TrainingPanels
{
    public class StepUI : MonoBehaviour
    {
        public Step Step => _step;
        
        [SerializeField] private TMP_Text _stepName;
        [SerializeField] private Image _background;
        [SerializeField] private Color _activeColor;
        [SerializeField] private Color _defaultColor;
        
        private Step _step;

        public void SetStepName(string stepName) => 
            _stepName.text = stepName;
        
        public void SetActiveStep(bool isActive) => 
            _background.color = isActive ? _activeColor : _defaultColor;
        
        public void SetStep(Step step) => 
            _step = step;
    }
}