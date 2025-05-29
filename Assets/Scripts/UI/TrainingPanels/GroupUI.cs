using Quests;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.TrainingPanels
{
    public class GroupUI : MonoBehaviour
    {
        public Group Group => _group;
        
        [SerializeField] private TMP_Text _groupName;
        [SerializeField] private Image _background;
        [SerializeField] private Color _activeColor;
        [SerializeField] private Color _defaultColor;
        
        private Group _group;

        public void SetGroupName(string groupName) => 
            _groupName.text = groupName;
        
        public void SetActiveState(bool isActive) => 
            _background.color = isActive ? _activeColor : _defaultColor;

        public void SetGroup(Group group) => 
            _group = group;
    }
}